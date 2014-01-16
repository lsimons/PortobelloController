using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
{
    public partial class BeamerOutput : Form
    {
        public BeamerOutput()
        {
            InitializeComponent();
        }

        private delegate void SetImageInvoke(Image img);

        public void SetImage(Image img)
        {
            if (this.InvokeRequired) {
                var invoker = new SetImageInvoke(SetImage);
                this.Invoke(invoker, img);
            } else {
                pbFront.BackgroundImage = img;
            }
        }

        private bool closeFormEnabled = false;
        public void ForceClose()
        {
            this.closeFormEnabled = true;
            this.Close();
        }

        private void BeamerOutput_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeFormEnabled) {
                e.Cancel = true;
            }
        }
    }
}
