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
        private int lastPosition;

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
            while (true) {
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
                    if (this.lastPosition != this.printerInterface.LiftPositionInUMFromTopSensor) {
                        this.lastPosition = this.printerInterface.LiftPositionInUMFromTopSensor / 1000;
                        this.mainForm.SetLiftPosition(this.lastPosition);
                    }
                }
                Thread.Sleep(100);
            }
        }

        internal void Close()
        {
            this.mainForm.StatusMessage("Interrupting the monitoring thread.");
            this.monitorThread.Interrupt();
        }
    }
}
