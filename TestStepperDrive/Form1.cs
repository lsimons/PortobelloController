using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestStepperDrive
{
    public partial class Form1 : Form
    {
        private LabjackPrinterInterface labJack;
        public Form1()
        {
            InitializeComponent();
            try {
                this.labJack = new LabjackPrinterInterface();
                string message;
                if (!this.labJack.TryConnect(out message)) {
                    MessageBox.Show("Check that labjack is connected and try again. Error: " + message);
                    Environment.Exit(1);
                }
                this.labJack.Reset();
            } catch (Exception err) {
                MessageBox.Show("Exception:\n" + err.ToString());
                Environment.Exit(1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                int microMeter;
                if (int.TryParse(this.txtPulses.Text, out microMeter)) {
                    if (this.cbDirUp.Checked) {
                        this.labJack.MoveLiftUp(microMeter);
                    } else {
                        this.labJack.MoveLiftDown(microMeter);
                    }
                } else {
                    MessageBox.Show("Input a number.");
                }
            } catch (Exception err) {
                MessageBox.Show("Exception:\n" + err.ToString());
                Environment.Exit(1);
            }
        }
    }
}
