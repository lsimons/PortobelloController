using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Controller
{
    public class SimulatedPrinterInterface : IPrinterInterface
    {
        private Main mainForm;
        // Stepper pulses per mm
        private const int PULSE_COUNT_PER_MM = 600;

        public SimulatedPrinterInterface(Main mainForm)
        {
            this.mainForm = mainForm;
            Reset();
        }
        private bool connected = false;
        public bool TryConnect(out string errorMessage)
        {
            errorMessage = "";
            this.mainForm.StatusMessage("Connected to simulator.");
            this.connected = true;
            return true;
        }

        public void Reset()
        {
            this.mainForm.StatusMessage("Hardware reset.");
            ResinPump = false;
            ReservoirValve = false;
            TopSensor = false;
            BottomSensor = false;
            LiftPositionInPulsesFromTopSensor = -1;
            LiftEnabled = true;
            FanEnabled = true;
        }

        public bool Connected
        {
            get { return this.connected; }
        }

        public bool ResinPump
        {
            get;
            set;
        }

        public bool ReservoirValve
        {
            get;
            set;
        }

        public bool LiftEnabled
        {
            get;
            set;
        }

        public bool FanEnabled
        {
            get;
            set;
        }

        public bool TopSensor
        {
            get;
            private set;
        }

        public bool BottomSensor
        {
            get;
            private set;
        }

        public void MoveLiftUp(int microMeter)
        {
            if (!TopSensor && this.LiftPositionInPulsesFromTopSensor > -1) {
                var pulseCount = UMToPulses(microMeter);
                this.LiftPositionInPulsesFromTopSensor -= pulseCount;
                this.mainForm.StatusMessage("Moving lift up " + microMeter.ToString() + "um");
                Thread.Sleep((int)(pulseCount / 5));
            }
        }

        private int UMToPulses(int microMeter)
        {
            return (int)(microMeter * (PULSE_COUNT_PER_MM / 1000d));
        }

        public void MoveLiftDown(int microMeter)
        {
            if (!BottomSensor) {
                var pulseCount = UMToPulses(microMeter);
                this.LiftPositionInPulsesFromTopSensor += pulseCount;
                this.mainForm.StatusMessage("Moving lift down " + microMeter.ToString() + "um");
                Thread.Sleep((int)(pulseCount / 5));
                if (this.LiftPositionInPulsesFromTopSensor < 0) {
                    this.LiftPositionInPulsesFromTopSensor = 0;
                }
                this.TopSensor = false;
            }
        }

        public void MoveLiftToTop()
        {
            LiftPositionInPulsesFromTopSensor = 0;
            this.mainForm.StatusMessage("Moving lift to top.");
            Thread.Sleep(2500);
            this.mainForm.StatusMessage("Moved lift to top.");
            this.TopSensor = true;
        }

        public void InitializePrinter()
        {
            this.mainForm.StatusMessage("Initialize lift");
        }

        public int LiftPositionInPulsesFromTopSensor
        {
            get;
            private set;
        }

        public int LiftPositionInUMFromTopSensor
        {
            get
            {
                if (this.LiftPositionInPulsesFromTopSensor == -1) {
                    return -1;
                } else {
                    return PulsesToUM(this.LiftPositionInPulsesFromTopSensor);
                }
            }
        }

        private int PulsesToUM(int pulseCount)
        {
            return (int)(pulseCount / (PULSE_COUNT_PER_MM / 1000d));
        }

        public void Disconnect()
        {
            this.connected = false;
        }
    }
}
