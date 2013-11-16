using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
                beamerForm.TopMost = false;
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

        private DateTime startTime = DateTime.Now;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.processor == null) {
                this.processor = new PrinterProcess(sliceFolderDlg.SelectedPath, this.beamerForm, this);
                this.processor.SetProjectionTime(this.projectionTimeMs);
                if (this.projectionTimeMsFirstGroup > 0) {
                    this.processor.SetProjectionTimeFirstGroup(this.projectionTimeMsFirstGroup, this.projectionTimeMsFirstGroupCount);
                }
                if (this.projectionTimeMsSecondGroup > 0) {
                    this.processor.SetProjectionTimeSecondGroup(this.projectionTimeMsSecondGroup, this.projectionTimeMsSecondGroupCount);
                }
                btnStart.Text = "Stop";
                this.processor.Start();
                this.startTime = DateTime.Now;
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


        private int projectionTimeMs = 1000;
        private void txtProjectionTimeMs_TextChanged(object sender, EventArgs e)
        {
            var oldValue = txtProjectionTimeMs.Text;
            this.projectionTimeMs = ValidateTextInputIsNumberAndReturnValue(txtProjectionTimeMs, 1000);
            if (this.processor != null) {
                if (!this.processor.SetProjectionTime(projectionTimeMs)) {
                    this.projectionTimeMs = int.Parse(oldValue);
                    this.txtProjectionTimeMs.Text = oldValue;
                }
            }
        }

        private int ValidateTextInputIsNumberAndReturnValue(TextBox txtBox, int defaultValue)
        {
            int value = defaultValue;
            var timeMs = Regex.Replace(txtBox.Text, @"[^0-9]", "");
            if (!string.IsNullOrWhiteSpace(timeMs)) {
                value = int.Parse(timeMs);
            } 
            txtBox.Text = value.ToString();
            return value;
        }

        private int projectionTimeMsFirstGroup = -1;
        private int projectionTimeMsFirstGroupCount = -1;
        private void txtProjectionTimeMsFirstGroup_TextChanged(object sender, EventArgs e)
        {
            var oldValue = txtProjectionTimeMsFirstGroup.Text;
            this.projectionTimeMs = ValidateTextInputIsNumberAndReturnValue(txtProjectionTimeMsFirstGroup, 1000);
            if (this.processor != null && this.projectionTimeMsFirstGroupCount > 0) {
                if (!this.processor.SetProjectionTimeFirstGroup(this.projectionTimeMsFirstGroup, this.projectionTimeMsFirstGroupCount)) {
                    this.projectionTimeMsFirstGroup = int.Parse(oldValue);
                    this.txtProjectionTimeMsFirstGroup.Text = oldValue;
                }
            }
        }

        private void txtFirstGroupCount_TextChanged(object sender, EventArgs e)
        {
            var oldValue = txtFirstGroupCount.Text;
            this.projectionTimeMsFirstGroupCount = ValidateTextInputIsNumberAndReturnValue(txtFirstGroupCount, 20);
            if (this.processor != null && this.projectionTimeMsFirstGroup > 0) {
                if (!this.processor.SetProjectionTimeFirstGroup(this.projectionTimeMsFirstGroup, this.projectionTimeMsFirstGroupCount)) {
                    this.projectionTimeMsFirstGroupCount = int.Parse(oldValue);
                    this.txtFirstGroupCount.Text = oldValue;
                }
            }
        }

        private int projectionTimeMsSecondGroup = -1;
        private int projectionTimeMsSecondGroupCount = -1;
        private void txtProjectionTimeMsSecondGroup_TextChanged(object sender, EventArgs e)
        {
            var oldValue = txtProjectionTimeMsSecondGroup.Text;
            this.projectionTimeMs = ValidateTextInputIsNumberAndReturnValue(txtProjectionTimeMsSecondGroup, 1000);
            if (this.processor != null && this.projectionTimeMsSecondGroupCount > 0) {
                if (!this.processor.SetProjectionTimeSecondGroup(this.projectionTimeMsSecondGroup, this.projectionTimeMsSecondGroupCount)) {
                    this.projectionTimeMsSecondGroup = int.Parse(oldValue);
                    this.txtProjectionTimeMsSecondGroup.Text = oldValue;
                }
            }
        }

        private void txtSecondGroupCount_TextChanged(object sender, EventArgs e)
        {
            var oldValue = txtSecondGroupCount.Text;
            this.projectionTimeMsSecondGroupCount = ValidateTextInputIsNumberAndReturnValue(txtSecondGroupCount, 20);
            if (this.processor != null && this.projectionTimeMsSecondGroup > 0) {
                if (!this.processor.SetProjectionTimeSecondGroup(this.projectionTimeMsSecondGroup, this.projectionTimeMsSecondGroupCount)) {
                    this.projectionTimeMsSecondGroupCount = int.Parse(oldValue);
                    this.txtSecondGroupCount.Text = oldValue;
                }
            }
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
                txtTimeRemaining.Text = CalculateRemainingTime();
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
        private int totalSlices = 0;
        internal void SetTotalSlices(int total)
        {
            if (this.InvokeRequired) {
                var invoker = new SetTotalSlicesInvoker(SetTotalSlices);
                this.Invoke(invoker, total);
            } else {
                this.totalSlices = total;
                txtTotalSlices.Text = total.ToString("000000");
                txtTimeRemaining.Text = CalculateRemainingTime();
                txtTimePassed.Text = CalculateTimePassed();
            }
        }

        private int EXPECTED_PRINTER_BUSY_TIME = 1800;
        private string CalculateRemainingTime()
        {
            var remainingMs = (this.totalSlices - this.currentSlice) * (double)(projectionTimeMs + EXPECTED_PRINTER_BUSY_TIME);
            var timeSpan = TimeSpan.FromMilliseconds(remainingMs);
            return timeSpan.ToString(@"hh\:mm\:ss");
        }

        private delegate void SetCurrentSliceInvoker(int current);
        private int currentSlice = 0;
        internal void SetCurrentSlice(int current)
        {
            if (this.InvokeRequired) {
                var invoker = new SetCurrentSliceInvoker(SetCurrentSlice);
                this.Invoke(invoker, current);
            } else {
                this.currentSlice = current;
                txtCurrentSlice.Text = current.ToString("000000");
                txtTimeRemaining.Text = CalculateRemainingTime();
                txtTimePassed.Text = CalculateTimePassed();
            }
        }

        private string CalculateTimePassed()
        {
            var timePassed = DateTime.Now - startTime;
            return timePassed.ToString(@"hh\:mm\:ss");
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void simulatePrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "PrinterTcpServerMock.exe";
            proc.Start();
        }
    }
}
