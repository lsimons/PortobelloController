using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
{
    public partial class Main : Form
    {
        private BeamerOutput beamerForm;
        private PrinterProcess processor;

        public Main()
        {
            InitializeComponent();
            this.beamerForm = new BeamerOutput();
            this.beamerForm.StartPosition = FormStartPosition.Manual;
            var beamerScreen = GetBeamerScreen();
            Rectangle bounds;
            if (beamerScreen != null) {
                bounds = beamerScreen.Bounds;
            } else {
                beamerForm.WindowState = FormWindowState.Normal;
                beamerForm.FormBorderStyle = FormBorderStyle.Sizable;
                bounds = new Rectangle(500, 10, 400, 400);
            }
            this.beamerForm.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            this.beamerForm.Show();
        }

        private static Screen GetBeamerScreen()
        {
            var screens = Screen.AllScreens;
            Screen beamer = null;
            foreach (var screen in screens) {
                if (!screen.Primary) {
                    beamer = screen;
                }
            }
            return beamer;
        }

        private void btnSliceFolder_Click(object sender, EventArgs e)
        {
            if (sliceFolderDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                txtFolder.Text = Path.GetFileName(sliceFolderDlg.SelectedPath);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.processor == null) {
                this.processor = new PrinterProcess(sliceFolderDlg.SelectedPath, this.beamerForm, this);
                this.processor.Start();
                btnStart.Text = "Stop";
            } else {
                this.processor.Stop();
            }
        }

        private delegate void StatusMessageInvoker(string message);
        public void StatusMessage(string message)
        {
            if (this.InvokeRequired) {
                var invoker = new StatusMessageInvoker(StatusMessage);
                this.Invoke(invoker, message);
            } else {
                this.txtStatus.AppendText(message + Environment.NewLine);
            }
        }

        private delegate void DoneInvoker();
        public void Done()
        {
            if (this.InvokeRequired) {
                var invoker = new DoneInvoker(Done);
                this.Invoke(invoker);
            } else {
                processor = null;
                progressBar.Value = 0;
                SetTotalSlices(0);
                SetCurrentSlice(0);
                StatusMessage("Done...");
                SetThumbnail(null);
                btnStart.Text = "Start";
                btnPause.Text = "Pause";
            }
        }

        private delegate void SetThumbnailInvoke(Image thumb);
        internal void SetThumbnail(Image thumb)
        {
            if (this.InvokeRequired) {
                var invoker = new SetThumbnailInvoke(SetThumbnail);
                this.Invoke(invoker, thumb);
            } else {
                this.pbLayerThumbnail.BackgroundImage = thumb;
            }
        }

        private void txtProjectionTimeMs_TextChanged(object sender, EventArgs e)
        {
            txtProjectionTimeMs.Text = Regex.Replace(txtProjectionTimeMs.Text, @"[^0-9]", "");
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (processor == null) {
                return;
            }
            processor.Pause = !processor.Pause;
            if (processor.Pause) {
                btnPause.Text = "Continue";
            } else {
                btnPause.Text = "Pause";
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (processor != null) {
                processor.Stop();
                int waitCount = 0;
                while (processor != null && waitCount++ < 40) {
                    Thread.Sleep(100);
                }
            }
        }

        private delegate void SetProgressInvoker(int percentage);
        internal void SetProgress(int percentage)
        {
            if (this.InvokeRequired) {
                var invoker = new SetProgressInvoker(SetProgress);
                this.Invoke(invoker, percentage);
            } else {
                progressBar.Value = percentage;
            }
        }

        private delegate void SetTotalSlicesInvoker(int total);
        internal void SetTotalSlices(int total)
        {
            if (this.InvokeRequired) {
                var invoker = new SetTotalSlicesInvoker(SetTotalSlices);
                this.Invoke(invoker, total);
            } else {
                txtTotalSlices.Text = total.ToString("000000");
            }
        }

        private delegate void SetCurrentSliceInvoker(int current);
        internal void SetCurrentSlice(int current)
        {
            if (this.InvokeRequired) {
                var invoker = new SetCurrentSliceInvoker(SetCurrentSlice);
                this.Invoke(invoker, current);
            } else {
                txtCurrentSlice.Text = current.ToString("000000");
            }
        }
    }
}
