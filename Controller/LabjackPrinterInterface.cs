﻿using LabJack.LabJackUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class LabjackPrinterInterface : IPrinterInterface
    {
        // Hardware configuration:
        // 0-7    FIO0-FIO7
        // 8-15   EIO0-EIO7
        // 16-19  CIO0-CIO3
        // PWM out: FIO4
        private const int PWM_OFFSET = 4;
        // Top sensor in: EIO0
        private const int TOP_SENSOR_IN = 8;
        // Bottom sensor in: EIO1
        private const int BOTTOM_SENSOR_IN = 9;
        // Emergency stop in (external): CIO0
        private const int EMERGENCY_STOP_IN = 16;
        // Motor direction out: EIO3
        private const int LIFT_DIR_OUT = 11;
        // Motor enable out: EIO4
        private const int LIFT_ENABLE_OUT = 12;
        // Pump enable out: EIO5
        private const int PUMP_ENABLE_OUT = 13;
        // Valve enable out: EIO6
        private const int VALVE_ENABLE_OUT = 14;
        // Maximum height to move
        private const int MAX_PULSE_COUNT_FROM_TOP = 10000;
        // Stepper pulses per mm
        private const int PULSE_COUNT_PER_MM = 600;

        private U3 labjackBoard;

        public bool TryConnect(out string message)
        {
            message = "";
            try {
                this.labjackBoard = new U3(LJUD.CONNECTION.USB, "0", true);
                this.Connected = true;
                return true;
            } catch (LabJackUDException err) {
                message = err.LJUDError.ToString() + ": " + err.Message;
                this.Connected = false;
                return false;
            }
        }

        public void Reset()
        {
            LJUD.ePut(this.labjackBoard.ljhandle, LJUD.IO.PIN_CONFIGURATION_RESET, 0, 0, 0);
            //Set the timer/counter pin offset to 4, which will put the first
            //timer/counter on FIO4.
            LJUD.AddRequest(this.labjackBoard.ljhandle, LJUD.IO.PUT_CONFIG, LJUD.CHANNEL.TIMER_COUNTER_PIN_OFFSET, LabjackPrinterInterface.PWM_OFFSET, 0, 0);

            //Use the 48 MHz timer clock base with divider.  Since we are using clock with divisor
            //support, Counter0 is not available.
            LJUD.AddRequest(this.labjackBoard.ljhandle, LJUD.IO.PUT_CONFIG, LJUD.CHANNEL.TIMER_CLOCK_BASE, (double)LJUD.TIMERCLOCKS.MHZ48_DIV, 0, 0);

            //Set the divisor to 75 so the actual timer clock is 0.64 MHz. (Needed to use PWM at 2.5kHz)
            LJUD.AddRequest(this.labjackBoard.ljhandle, LJUD.IO.PUT_CONFIG, LJUD.CHANNEL.TIMER_CLOCK_DIVISOR, 75, 0, 0);

            //Execute the requests.
            LJUD.GoOne(this.labjackBoard.ljhandle);
            
            // Set outputs
            ResinPump = false;
            ReservoirValve = false;
        }

        public bool Connected { get; private set; }

        private bool resinPump = false;
        public bool ResinPump
        {
            get
            {
                return this.resinPump;
            }
            set
            {
                this.resinPump = value;
                LJUD.ePut(this.labjackBoard.ljhandle, LJUD.IO.PUT_DIGITAL_BIT, LabjackPrinterInterface.PUMP_ENABLE_OUT, this.resinPump ? 1 : 0, 0);
            }
        }

        private bool reservoirValve = false;
        public bool ReservoirValve
        {
            get
            {
                return this.reservoirValve;
            }
            set
            {
                this.reservoirValve = true;
                LJUD.ePut(this.labjackBoard.ljhandle, LJUD.IO.PUT_DIGITAL_BIT, LabjackPrinterInterface.VALVE_ENABLE_OUT, this.reservoirValve ? 1 : 0, 0);
            }
        }

        public bool TopSensor
        {
            get
            {
                double val = 0;
                LJUD.eGet(this.labjackBoard.ljhandle, LJUD.IO.GET_DIGITAL_BIT, LabjackPrinterInterface.TOP_SENSOR_IN, ref val, 0);
                if (val == 0) {
                    return false;
                } else {
                    return true;
                }
            }
        }

        public bool BottomSensor
        {
            get
            {
                double val = 0;
                LJUD.eGet(this.labjackBoard.ljhandle, LJUD.IO.GET_DIGITAL_BIT, LabjackPrinterInterface.BOTTOM_SENSOR_IN, ref val, 0);
                if (val == 0) {
                    return false;
                } else {
                    return true;
                }
            }
        }

        private void MovePulses(int pulseCount, bool moveUp)
        {
            if (pulseCount <= 0) {
                return;
            }
            // Basically works like this:
            // 1. Set timer0 as a PWM driver which counts to 8bit, duty cycle 50% (essentially dividing clock frequency by 256)
            // 2. Set timer1 as a stop timer which counts to 'pulseCount' and stops timer0 once stop count is reached
            // 3. Push to U3 board
            // 4. Wait for timer1 to indicate the 'pulseCount' is reached

            //Enable 2 timers.  They will use FIO4-FIO5.
            LJUD.AddRequest(this.labjackBoard.ljhandle, LJUD.IO.PUT_CONFIG, LJUD.CHANNEL.NUMBER_TIMERS_ENABLED, 2, 0, 0);

            //Configure Timer0 as 8-bit PWM.  Frequency will be 0.64M/2^8 ~ 2.5 kHz.
            LJUD.AddRequest(this.labjackBoard.ljhandle, LJUD.IO.PUT_TIMER_MODE, 0, (double)LJUD.TIMERMODE.PWM8, 0, 0);

            //Set the PWM duty cycle to 50%.
            LJUD.AddRequest(this.labjackBoard.ljhandle, LJUD.IO.PUT_TIMER_VALUE, 0, 32768, 0, 0);

            // Timer1 is used to stop timer0 after specified interval count.
            LJUD.AddRequest(this.labjackBoard.ljhandle, LJUD.IO.PUT_TIMER_MODE, 1, (double)LJUD.TIMERMODE.TIMERSTOP, 0, 0);
            
            //Set the PWM duty cycle to 50%.
            LJUD.AddRequest(this.labjackBoard.ljhandle, LJUD.IO.PUT_TIMER_VALUE, 1, pulseCount, 0, 0);

            // Move in the right direction
            LJUD.AddRequest(this.labjackBoard.ljhandle, LJUD.IO.PUT_DIGITAL_BIT, LabjackPrinterInterface.LIFT_DIR_OUT, (moveUp ? 1 : 0), 0, 0);

            //Execute the requests.
            LJUD.GoOne(this.labjackBoard.ljhandle);

            // Value is unsigned 32 bit int
            // The MSW of the read from this timer mode returns the number of edges counted, but does not increment
            // past the stop count value.  The LSW of the read returns edges waiting for.
            double timer1Val = 0;
            do {
                LJUD.eGet(this.labjackBoard.ljhandle, LJUD.IO.GET_TIMER, 1, ref timer1Val, 0);
            } while ((((UInt32)timer1Val) & 0xFFFFu) != 0);
        }

        public void MoveLiftUp(int microMeter)
        {
            var pulseCount = UMToPulses(microMeter);
            if (LiftPositionInPulsesFromTopSensor > 0 &&
                LiftPositionInPulsesFromTopSensor < pulseCount) {
                pulseCount = LiftPositionInPulsesFromTopSensor;
            }
            if (!TopSensor) {
                MovePulses(pulseCount, true);
            }
            if (LiftPositionInPulsesFromTopSensor != -1) {
                LiftPositionInPulsesFromTopSensor -= pulseCount;
            }
        }

        private int UMToPulses(int microMeter)
        {
            return (int)(microMeter * (PULSE_COUNT_PER_MM / 1000d));
        }

        public void MoveLiftDown(int microMeter)
        {
            var pulseCount = UMToPulses(microMeter);
            if ((LiftPositionInPulsesFromTopSensor + pulseCount) > MAX_PULSE_COUNT_FROM_TOP) {
                pulseCount = MAX_PULSE_COUNT_FROM_TOP - LiftPositionInPulsesFromTopSensor;
            }
            if (!BottomSensor) {
                MovePulses(pulseCount, false);
            }
            if (LiftPositionInPulsesFromTopSensor != -1) {
                LiftPositionInPulsesFromTopSensor += pulseCount;
            }
        }

        public void MoveLiftToTop()
        {
            while (!TopSensor) {
                MovePulses(500, true);
            }
            while (TopSensor) {
                MovePulses(60, false);
            }
            while (!TopSensor) {
                MovePulses(30, true);
            }
            LiftPositionInPulsesFromTopSensor = 0;
        }

        private int liftPositionInPulsesFromTopSensor = -1;
        public int LiftPositionInPulsesFromTopSensor
        {
            get
            {
                return this.liftPositionInPulsesFromTopSensor;
            }
            private set
            {
                if (value < 0) {
                    this.liftPositionInPulsesFromTopSensor = -1;
                } else {
                    this.liftPositionInPulsesFromTopSensor = value;
                }
            }
        }

        public int LiftPositionInUMFromTopSensor
        {
            get
            {
                if (this.liftPositionInPulsesFromTopSensor == -1) {
                    return -1;
                } else {
                    return PulsesToUM(this.liftPositionInPulsesFromTopSensor);
                }
            }
        }

        private int PulsesToUM(int pulseCount)
        {
            return (int)(pulseCount / (PULSE_COUNT_PER_MM / 1000d));
        }
    }
}