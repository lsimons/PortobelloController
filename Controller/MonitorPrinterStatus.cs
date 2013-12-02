using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    class MonitorPrinterStatus
    {
        private IPrinterInterface printerInterface;
        public MonitorPrinterStatus(IPrinterInterface printerInterface)
        {
            this.printerInterface = printerInterface;
        }
    }
}
