using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Controller
{
    class MonitorPrinterStatus
    {
        private IPrinterInterface printerInterface;
        private Main mainForm;
        private Thread monitorThread;
        private bool bottomSensor;
        private bool topSensor;
        private bool resinPump;
        private bool reservoirValve;
        private decimal lastPosition;
        private bool running = false;

        public MonitorPrinterStatus(IPrinterInterface printerInterface, Main mainForm)
        {
            this.printerInterface = printerInterface;
            this.mainForm = mainForm;
            this.monitorThread = new Thread(Run);
            this.monitorThread.IsBackground = true;
            this.monitorThread.Start();
        }

        private void Run()
        {
            this.mainForm.StatusMessage("Start monitoring printer");
            this.running = true;
            while (this.running) {
                try {
                    Thread.Sleep(100);
                } catch (ThreadInterruptedException) {
                    break;
                }
                if (this.bottomSensor != this.printerInterface.BottomSensor) {
                    this.bottomSensor = !this.bottomSensor;
                    this.mainForm.SetBottomSensor(this.bottomSensor);
                }
                if (this.topSensor != this.printerInterface.TopSensor) {
                    this.topSensor = !this.topSensor;
                    this.mainForm.SetTopSensor(this.topSensor);
                }
                if (this.resinPump != this.printerInterface.ResinPump) {
                    this.resinPump = !this.resinPump;
                    this.mainForm.SetResinPump(this.resinPump);
                }
                if (this.reservoirValve != this.printerInterface.ReservoirValve) {
                    this.reservoirValve = !this.reservoirValve;
                    this.mainForm.SetReservoirValve(this.reservoirValve);
                }
                if (this.printerInterface.LiftPositionInUMFromTopSensor != -1) {
                    var curPos = Math.Round(this.printerInterface.LiftPositionInUMFromTopSensor / 1000m, 1);
                    if (this.lastPosition != curPos) {
                        this.lastPosition = curPos;
                        this.mainForm.SetLiftPosition(this.lastPosition);
                    }
                }
            }
            this.mainForm.MonitoringDone();
        }

        internal void Stop()
        {
            this.running = false;
        }

        internal void Close()
        {
            this.mainForm.StatusMessage("Interrupting the monitoring thread.");
            this.monitorThread.Interrupt();
        }
    }
}
