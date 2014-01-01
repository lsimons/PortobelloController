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
        private IPrinterInterface printerInterface;
        private MonitorPrinterStatus monitorPrinter;
        private MachineConfig machineConfig;

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
            this.machineConfig = new MachineConfig();
            this.txtProjectionTimeMs.Text = this.projectionTimeMs.ToString();
            this.txtProjectionTimeMsFirstGroup.Text = this.projectionTimeMsFirstGroup.ToString();
            this.txtProjectionTimeMsSecondGroup.Text = this.projectionTimeMsSecondGroup.ToString();
            this.txtFirstGroupCount.Text = this.projectionTimeMsFirstGroupCount.ToString();
            this.txtSecondGroupCount.Text = this.projectionTimeMsSecondGroupCount.ToString();
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
                if (string.IsNullOrWhiteSpace(sliceFolderDlg.SelectedPath)) {
                    MessageBox.Show("Select a folder with images first.");
                } else {
                    this.processor = new PrinterProcess(sliceFolderDlg.SelectedPath, this.beamerForm, this, this.printerInterface, this.machineConfig);
                    this.processor.SetProjectionTime(this.projectionTimeMs);
                    if (this.projectionTimeMsFirstGroup > 0) {
                        this.processor.SetProjectionTimeFirstGroup(this.projectionTimeMsFirstGroup, this.projectionTimeMsFirstGroupCount);
                    }
                    if (this.projectionTimeMsSecondGroup > 0) {
                        this.processor.SetProjectionTimeSecondGroup(this.projectionTimeMsSecondGroup, this.projectionTimeMsSecondGroupCount);
                    }
                    btnStart.Image = Properties.Resources.glyphicons_175_stop;
                    btnStart.Text = "Stop";
                    ToolTipHelp.SetToolTip(btnStart, "Stop printing process.");
                    this.processor.Start();
                    this.startTime = DateTime.Now;
                }
            } else {
                this.StatusMessage("Stopping printer process, please wait...");
                this.processor.Stop();
                btnStart.Enabled = false;
                btnPause.Enabled = false;
            }
        }

        private delegate void StatusMessageInvoker(string message);
        public void StatusMessage(string message)
        {
            if (this.InvokeRequired) {
                var invoker = new StatusMessageInvoker(StatusMessage);
                this.Invoke(invoker, message);
            } else {
                var formattedMessage = DateTime.Now.ToString("hh:mm:ss") + ": " + message + Environment.NewLine;
                this.txtStatus.AppendText(formattedMessage);
                Trace.Write(formattedMessage);
            }
        }

        private delegate void ProcessorDoneInvoker();
        public void ProcessorDone()
        {
            if (this.InvokeRequired) {
                var invoker = new ProcessorDoneInvoker(ProcessorDone);
                this.Invoke(invoker);
            } else {
                processor = null;
                progressBar.Value = 0;
                SetTotalSlices(0);
                SetCurrentSlice(0);
                StatusMessage("Done...");
                SetThumbnail(null);
                btnStart.Enabled = true;
                btnPause.Enabled = true;
                btnStart.Image = Properties.Resources.glyphicons_173_play;
                btnStart.Text = "Start";
                ToolTipHelp.SetToolTip(btnStart, "Start printing process.");
                btnPause.Image = Properties.Resources.glyphicons_174_pause;
                btnPause.Text = "Pause";
                if (this.mainFormClosing) {
                    this.Close();
                }
            }
        }

        private delegate void MonitoringDoneInvoker();
        public void MonitoringDone()
        {
            if (this.InvokeRequired) {
                var invoker = new MonitoringDoneInvoker(MonitoringDone);
                this.Invoke(invoker);
            } else {
                this.monitorPrinter = null;
                if (this.mainFormClosing) {
                    this.Close();
                }
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


        private int projectionTimeMs = 2400;
        private void txtProjectionTimeMs_TextChanged(object sender, EventArgs e)
        {
            var oldValue = txtProjectionTimeMs.Text;
            this.projectionTimeMs = ValidateTextInputIsNumberAndReturnValue(txtProjectionTimeMs, 2400);
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

        private int projectionTimeMsFirstGroup = 15000;
        private int projectionTimeMsFirstGroupCount = 3;
        private void txtProjectionTimeMsFirstGroup_TextChanged(object sender, EventArgs e)
        {
            var oldValue = txtProjectionTimeMsFirstGroup.Text;
            this.projectionTimeMsFirstGroup = ValidateTextInputIsNumberAndReturnValue(txtProjectionTimeMsFirstGroup, 1000);
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

        private int projectionTimeMsSecondGroup = 3000;
        private int projectionTimeMsSecondGroupCount = 5;
        private void txtProjectionTimeMsSecondGroup_TextChanged(object sender, EventArgs e)
        {
            var oldValue = txtProjectionTimeMsSecondGroup.Text;
            this.projectionTimeMsSecondGroup = ValidateTextInputIsNumberAndReturnValue(txtProjectionTimeMsSecondGroup, 1000);
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
                btnPause.Image = Properties.Resources.glyphicons_173_play;
                btnPause.Text = "Continue";
                ToolTipHelp.SetToolTip(btnPause, "Continue the printing process.");
            } else {
                txtTimeRemaining.Text = CalculateRemainingTime();
                btnPause.Image = Properties.Resources.glyphicons_174_pause;
                btnPause.Text = "Pause";
                ToolTipHelp.SetToolTip(btnPause, "Pause the printing process.");
            }
        }

        private bool mainFormClosing = false;
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mainFormClosing = true;
            if (this.monitorPrinter != null) {
                this.monitorPrinter.Stop();
                e.Cancel = true;
            } else if (this.processor != null) {
                this.processor.Stop();
                e.Cancel = true;
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
                txtTotalSlices.Text = total.ToString("##0000");
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
                txtCurrentSlice.Text = current.ToString("##0000");
                txtTimeRemaining.Text = CalculateRemainingTime();
                txtTimePassed.Text = CalculateTimePassed();
            }
        }

        private string CalculateTimePassed()
        {
            var timePassed = DateTime.Now - startTime;
            return timePassed.ToString(@"hh\:mm\:ss");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void simulatePrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.processor != null) {
                MessageBox.Show("Printer is active, stop first and allow process to finish before changing simulation mode.", "Cannot switch simulation mode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var simulationText = " - Simulating printer";
            this.simulatePrinterToolStripMenuItem.Checked = !this.simulatePrinterToolStripMenuItem.Checked;
            if (this.simulatePrinterToolStripMenuItem.Checked) {
                this.Text += simulationText;
            } else {
                this.Text = this.Text.Replace(simulationText, "");
            }
        }

        private bool emergencyStopPressed = false;
        private void btnEmergencyStop_Click(object sender, EventArgs e)
        {
            this.emergencyStopPressed = !this.emergencyStopPressed;
            if (this.emergencyStopPressed) {
                this.btnEmergencyStop.Image = Properties.Resources.continue_after_emergency;
                this.btnEmergencyStop.Text = "CONTINUE";
                if (this.printerInterface != null) {
                    this.printerInterface.LiftEnabled = false;
                }
            } else {
                this.btnEmergencyStop.Image = Properties.Resources.emergency_stop;
                this.btnEmergencyStop.Text = "EMERGENCY\nSTOP";
                if (this.printerInterface != null) {
                    this.printerInterface.LiftEnabled = true;
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (this.btnConnect.Text == "Connect") {
                if (this.simulatePrinterToolStripMenuItem.Checked) {
                    this.printerInterface = new SimulatedPrinterInterface(this);
                } else {
                    this.printerInterface = new LabjackPrinterInterface();
                }
                string errors;
                if (!this.printerInterface.TryConnect(out errors)) {
                    this.StatusMessage("Error connecting: " + errors);
                    this.printerInterface = null;
                } else {
                    this.printerInterface.Reset();
                    this.btnStart.Enabled = true;
                    this.btnPause.Enabled = true;
                    btnConnect.Image = Properties.Resources.glyphicons_265_electrical_plug_on;
                    btnConnect.Text = "Disconnect";
                    this.monitorPrinter = new MonitorPrinterStatus(this.printerInterface, this);
                }
            } else {
                if (this.processor != null) {
                    if (MessageBox.Show("Are you sure you want to disconnect now?", "Are you sure?", MessageBoxButtons.OKCancel) ==
                        System.Windows.Forms.DialogResult.Cancel
                    ) {
                        return;
                    }
                    this.processor.Stop();
                }
                if (this.monitorPrinter != null) {
                    this.monitorPrinter.Close();
                }
                if (this.printerInterface != null) {
                    this.printerInterface.Disconnect();
                }
                this.printerInterface = null;
                this.btnStart.Enabled = false;
                this.btnPause.Enabled = false;
                btnConnect.Image = Properties.Resources.glyphicons_265_electrical_plug;
                btnConnect.Text = "Connect";
            }
        }

        private delegate void SetBottomStateInvoker(bool state);
        internal void SetBottomSensor(bool state)
        {
            if (this.InvokeRequired) {
                var handle = new SetBottomStateInvoker(SetBottomSensor);
                this.Invoke(handle, state);
            } else {
                if (state) {
                    this.ledBottomSensor.BackgroundImage = Properties.Resources.led_blue;
                } else {
                    this.ledBottomSensor.BackgroundImage = Properties.Resources.led_off;
                }
            }
        }

        internal void SetTopSensor(bool state)
        {
            if (this.InvokeRequired) {
                var handle = new SetBottomStateInvoker(SetTopSensor);
                this.Invoke(handle, state);
            } else {
                if (state) {
                    this.ledTopSensor.BackgroundImage = Properties.Resources.led_blue;
                } else {
                    this.ledTopSensor.BackgroundImage = Properties.Resources.led_off;
                }
            }
        }

        internal void SetResinPump(bool state)
        {
            if (this.InvokeRequired) {
                var handle = new SetBottomStateInvoker(SetResinPump);
                this.Invoke(handle, state);
            } else {
                if (state) {
                    this.ledInkPump.BackgroundImage = Properties.Resources.led_blue;
                } else {
                    this.ledInkPump.BackgroundImage = Properties.Resources.led_off;
                }
            }
        }

        internal void SetReservoirValve(bool state)
        {
            if (this.InvokeRequired) {
                var handle = new SetBottomStateInvoker(SetReservoirValve);
                this.Invoke(handle, state);
            } else {
                if (state) {
                    this.ledEmptyVat.BackgroundImage = Properties.Resources.led_blue;
                } else {
                    this.ledEmptyVat.BackgroundImage = Properties.Resources.led_off;
                }
            }
        }

        private delegate void SetLiftPositionInvoker(int position);
        internal void SetLiftPosition(int position)
        {
            if (this.InvokeRequired) {
                var invoker = new SetLiftPositionInvoker(SetLiftPosition);
                this.Invoke(invoker, position);
            } else {
                this.lblPositionFromTopMm.Text = position.ToString();
            }
        }

        private async void btnMoveToTop_Click(object sender, EventArgs e)
        {
            if (this.printerInterface != null && this.processor == null) {
                this.btnMoveToTop.Enabled = false;
                await Task.Run(new Action(this.printerInterface.MoveLiftToTop));
                this.btnMoveToTop.Enabled = true;
            }
        }

        private async void btnInitialize_Click(object sender, EventArgs e)
        {
            if (this.printerInterface != null && this.processor == null) {
                this.btnInitialize.Enabled = false;
                this.printerInterface.InitializePrintHeightUm = this.machineConfig.InitializePositionFromTopSensorMu;
                this.printerInterface.ResinPump = true;
                await Task.Run(new Action(this.printerInterface.InitializePrinter));
                this.StatusMessage("Allow resin pump to run a bit longer to fill reservoir. (" + this.machineConfig.PumpTimeAfterInitializeSeconds + " seconds)");
                await Task.Run(() => {
                    Thread.Sleep(this.machineConfig.PumpTimeAfterInitializeSeconds * 1000);
                    this.printerInterface.ResinPump = false;
                });
                this.btnInitialize.Enabled = true;
            }
        }

        private bool resinPump = false;
        private void btnInkPump_Click(object sender, EventArgs e)
        {
            if (this.printerInterface != null && this.processor == null) {
                this.resinPump = !this.resinPump;
                if (this.resinPump) {
                    this.printerInterface.ResinPump = true;
                    this.btnInkPump.Image = Properties.Resources.fill_on;
                } else {
                    this.printerInterface.ResinPump = false;
                    this.btnInkPump.Image = Properties.Resources.fill;
                }
            } else {
                if (this.printerInterface != null) {
                    this.printerInterface.ResinPump = false;
                }
                this.btnInkPump.Image = Properties.Resources.fill;
            }
        }

        private bool drainReservoirActive = false;
        private void btnDrainReservoir_Click(object sender, EventArgs e)
        {
            if (this.printerInterface != null && this.processor == null) {
                this.drainReservoirActive = !this.drainReservoirActive;
                if (drainReservoirActive) {
                    this.printerInterface.ReservoirValve = true;
                    this.btnDrainReservoir.Image = Properties.Resources.drain_on;
                } else {
                    this.printerInterface.ReservoirValve = false;
                    this.btnDrainReservoir.Image = Properties.Resources.drain;
                }
            } else {
                if (this.printerInterface != null) {
                    this.printerInterface.ReservoirValve = false;
                }
                this.btnDrainReservoir.Image = Properties.Resources.drain;
            }
        }

        private void btnLiftUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                this.StatusMessage("Begin manual lift moving up.");
                BeginMoveUp();
            }
        }

        private bool liftMovingUp = false;
        private void BeginMoveUp()
        {
            this.liftMovingUp = true;
            new Thread(() => {
                while (this.liftMovingUp && this.printerInterface != null && this.processor == null) {
                    this.printerInterface.MoveLiftUp(200);
                }
            }).Start();
        }

        private void btnLiftUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                EndMoveUp();
            }
        }

        private void EndMoveUp()
        {
            if (this.liftMovingUp) {
                this.StatusMessage("End manual lift moving up.");
                this.liftMovingUp = false;
            }
        }

        private void btnLiftUp_MouseLeave(object sender, EventArgs e)
        {
            EndMoveUp();
        }

        private void btnLiftDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                this.StatusMessage("Begin manual lift moving down.");
                BeginMoveDown();
            }
        }

        private bool liftMovingDown = false;
        private void BeginMoveDown()
        {
            this.liftMovingDown = true;
            new Thread(() => {
                while (this.liftMovingDown && this.printerInterface != null && this.processor == null) {
                    this.printerInterface.MoveLiftDown(200);
                }
            }).Start();
        }

        private void btnLiftDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                EndMoveDown();
            }
        }

        private void EndMoveDown()
        {
            if (this.liftMovingDown) {
                this.StatusMessage("End manual lift moving down.");
                this.liftMovingDown = false;
            }
        }

        private void btnLiftDown_MouseLeave(object sender, EventArgs e)
        {
            EndMoveDown();
        }

        private void hardwareConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.printerInterface == null && this.processor == null) {
                this.machineConfig.StartPosition = FormStartPosition.Manual;
                this.machineConfig.Location = new Point(this.Location.X + 40, this.Location.Y + 30);
                this.machineConfig.ShowDialog(this);
            } else {
                MessageBox.Show("Only change when not connected to the printer, stop printing and disconnect first.", "Disconnect...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSaveAsInitialPos_Click(object sender, EventArgs e)
        {
            if (this.printerInterface != null && this.printerInterface.LiftPositionInUMFromTopSensor > 0) {
                var dialogResult = MessageBox.Show("Are you sure you want to set the initial position to the current lift position (" + this.printerInterface.LiftPositionInUMFromTopSensor.ToString() + "um from top sensor)?", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == System.Windows.Forms.DialogResult.OK) {
                    this.machineConfig.InitializePositionFromTopSensorMu = this.printerInterface.LiftPositionInUMFromTopSensor;
                }
            } else {
                MessageBox.Show("Cannot store position, make sure printer is connected and position is not -1", "Warning, no changes made", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet. Scheduled for next release.");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet. Scheduled for next release.");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet. Scheduled for next release.");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet. Scheduled for next release.");
        }
    }
}
