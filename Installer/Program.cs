using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;

namespace Installer
{
    class Program
    {
        public static void Main() {
            var main = new LabjackPrinterInterface();
            if (main != null) {
                Console.WriteLine("Not intended as a program, project contains installer files");
            }
        }
    }
}
