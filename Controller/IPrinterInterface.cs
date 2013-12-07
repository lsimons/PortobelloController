using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
    public interface IPrinterInterface
    {
        /// <summary>
        /// Tries to connect, false on error
        /// </summary>
        /// <param name="message">Set when returning false</param>
        /// <returns>Connection result</returns>
        bool TryConnect(out string errorMessage);

        /// <summary>
        /// Resets printer to defaults
        /// </summary>
        void Reset();

        /// <summary>
        /// Connection status
        /// </summary>
        bool Connected { get; }

        /// <summary>
        /// Start / Stop resin pump when set, read to get status
        /// </summary>
        bool ResinPump { get; set; }

        /// <summary>
        /// Open or close valve when set, read to get current status
        /// Resevoir valve allows resevoir to drain to vat
        /// </summary>
        bool ReservoirValve { get; set; }

        /// <summary>
        /// Set lift output to be enabled or disabled
        /// </summary>
        bool LiftEnabled { get; set; }

        /// <summary>
        /// Set fan output to be enabled or disabled
        /// </summary>
        bool FanEnabled { get; set; }

        /// <summary>
        /// Active when lift is at top position
        /// </summary>
        bool TopSensor { get; }

        /// <summary>
        /// Active when lift is at bottom position
        /// </summary>
        bool BottomSensor { get; }

        /// <summary>
        /// Move lift up
        /// </summary>
        /// <param name="pulseCount">Number of pulses to send to stepper motor</param>
        void MoveLiftUp(int microMeter);

        /// <summary>
        /// Move lift down
        /// </summary>
        /// <param name="pulseCount">Number of pulses to send to stepper motor</param>
        void MoveLiftDown(int microMeter);

        /// <summary>
        /// Move lift to top position
        /// </summary>
        void MoveLiftToTop();

        /// <summary>
        /// Current position in pulses from top sensor if known, -1 if unknown. Move to top if unknown to set to 0.
        /// </summary>
        int LiftPositionInPulsesFromTopSensor { get; }

        /// <summary>
        /// Current position in micrometer from top sensor if known, -1 if unknown. Move to top if unknown to set to 0.
        /// </summary>
        int LiftPositionInUMFromTopSensor { get; }

        /// <summary>
        /// Safely disconnect from the printer
        /// </summary>
        void Disconnect();
    }
}
