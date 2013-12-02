namespace Controller
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.sliceFolderDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSliceFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.txtProjectionTimeMs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentSlice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalSlices = new System.Windows.Forms.Label();
            this.txtProjectionTimeMsFirstGroup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProjectionTimeMsSecondGroup = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFirstGroupCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSecondGroupCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardwareConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulatePrinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTimeRemaining = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTimePassed = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.pbLayerThumbnail = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.btnEmergencyStop = new System.Windows.Forms.Button();
            this.btnDrainReservoir = new System.Windows.Forms.Button();
            this.btnInkPump = new System.Windows.Forms.Button();
            this.btnLiftDown = new System.Windows.Forms.Button();
            this.btnLiftUp = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.ledEmptyVat = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.ledInkPump = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ledBottomSensor = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblPositionFromTopMm = new System.Windows.Forms.Label();
            this.ledTopSensor = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLayerThumbnail)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledEmptyVat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledInkPump)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBottomSensor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTopSensor)).BeginInit();
            this.SuspendLayout();
            // 
            // sliceFolderDlg
            // 
            this.sliceFolderDlg.Description = "Select a folder with slice images (in alfabetical order) to be printed.";
            this.sliceFolderDlg.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // btnSliceFolder
            // 
            this.btnSliceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSliceFolder.Location = new System.Drawing.Point(509, 5);
            this.btnSliceFolder.Name = "btnSliceFolder";
            this.btnSliceFolder.Size = new System.Drawing.Size(42, 23);
            this.btnSliceFolder.TabIndex = 1;
            this.btnSliceFolder.Text = "...";
            this.btnSliceFolder.UseVisualStyleBackColor = true;
            this.btnSliceFolder.Click += new System.EventHandler(this.btnSliceFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Slice folder";
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(124, 7);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(379, 20);
            this.txtFolder.TabIndex = 0;
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Location = new System.Drawing.Point(15, 138);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(316, 237);
            this.txtStatus.TabIndex = 15;
            this.txtStatus.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Projection time (ms)";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(15, 109);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(534, 23);
            this.progressBar.TabIndex = 14;
            // 
            // txtProjectionTimeMs
            // 
            this.txtProjectionTimeMs.Location = new System.Drawing.Point(122, 83);
            this.txtProjectionTimeMs.Name = "txtProjectionTimeMs";
            this.txtProjectionTimeMs.Size = new System.Drawing.Size(48, 20);
            this.txtProjectionTimeMs.TabIndex = 6;
            this.txtProjectionTimeMs.Text = "1000";
            this.txtProjectionTimeMs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProjectionTimeMs.TextChanged += new System.EventHandler(this.txtProjectionTimeMs_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Slices";
            // 
            // txtCurrentSlice
            // 
            this.txtCurrentSlice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentSlice.AutoSize = true;
            this.txtCurrentSlice.Location = new System.Drawing.Point(452, 178);
            this.txtCurrentSlice.Name = "txtCurrentSlice";
            this.txtCurrentSlice.Size = new System.Drawing.Size(43, 13);
            this.txtCurrentSlice.TabIndex = 21;
            this.txtCurrentSlice.Text = "000000";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(495, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "/";
            // 
            // txtTotalSlices
            // 
            this.txtTotalSlices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalSlices.AutoSize = true;
            this.txtTotalSlices.Location = new System.Drawing.Point(506, 178);
            this.txtTotalSlices.Name = "txtTotalSlices";
            this.txtTotalSlices.Size = new System.Drawing.Size(43, 13);
            this.txtTotalSlices.TabIndex = 23;
            this.txtTotalSlices.Text = "000000";
            // 
            // txtProjectionTimeMsFirstGroup
            // 
            this.txtProjectionTimeMsFirstGroup.Location = new System.Drawing.Point(122, 31);
            this.txtProjectionTimeMsFirstGroup.Name = "txtProjectionTimeMsFirstGroup";
            this.txtProjectionTimeMsFirstGroup.Size = new System.Drawing.Size(48, 20);
            this.txtProjectionTimeMsFirstGroup.TabIndex = 2;
            this.txtProjectionTimeMsFirstGroup.Text = "0";
            this.txtProjectionTimeMsFirstGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProjectionTimeMsFirstGroup.TextChanged += new System.EventHandler(this.txtProjectionTimeMsFirstGroup_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Projection time (ms)";
            // 
            // txtProjectionTimeMsSecondGroup
            // 
            this.txtProjectionTimeMsSecondGroup.Location = new System.Drawing.Point(122, 57);
            this.txtProjectionTimeMsSecondGroup.Name = "txtProjectionTimeMsSecondGroup";
            this.txtProjectionTimeMsSecondGroup.Size = new System.Drawing.Size(48, 20);
            this.txtProjectionTimeMsSecondGroup.TabIndex = 4;
            this.txtProjectionTimeMsSecondGroup.Text = "0";
            this.txtProjectionTimeMsSecondGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProjectionTimeMsSecondGroup.TextChanged += new System.EventHandler(this.txtProjectionTimeMsSecondGroup_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Projection time (ms)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(176, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "for";
            // 
            // txtFirstGroupCount
            // 
            this.txtFirstGroupCount.Location = new System.Drawing.Point(201, 31);
            this.txtFirstGroupCount.Name = "txtFirstGroupCount";
            this.txtFirstGroupCount.Size = new System.Drawing.Size(33, 20);
            this.txtFirstGroupCount.TabIndex = 3;
            this.txtFirstGroupCount.Text = "0";
            this.txtFirstGroupCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFirstGroupCount.TextChanged += new System.EventHandler(this.txtFirstGroupCount_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(240, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "layers";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(240, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "layers";
            // 
            // txtSecondGroupCount
            // 
            this.txtSecondGroupCount.Location = new System.Drawing.Point(201, 57);
            this.txtSecondGroupCount.Name = "txtSecondGroupCount";
            this.txtSecondGroupCount.Size = new System.Drawing.Size(33, 20);
            this.txtSecondGroupCount.TabIndex = 5;
            this.txtSecondGroupCount.Text = "0";
            this.txtSecondGroupCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSecondGroupCount.TextChanged += new System.EventHandler(this.txtSecondGroupCount_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(176, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "for";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(177, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "for remaining layers";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hardwareConfigurationToolStripMenuItem,
            this.simulatePrinterToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // hardwareConfigurationToolStripMenuItem
            // 
            this.hardwareConfigurationToolStripMenuItem.Name = "hardwareConfigurationToolStripMenuItem";
            this.hardwareConfigurationToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.hardwareConfigurationToolStripMenuItem.Text = "Hardware configuration";
            // 
            // simulatePrinterToolStripMenuItem
            // 
            this.simulatePrinterToolStripMenuItem.Name = "simulatePrinterToolStripMenuItem";
            this.simulatePrinterToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.simulatePrinterToolStripMenuItem.Text = "Simulate printer";
            this.simulatePrinterToolStripMenuItem.Click += new System.EventHandler(this.simulatePrinterToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // txtTimeRemaining
            // 
            this.txtTimeRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimeRemaining.AutoSize = true;
            this.txtTimeRemaining.Location = new System.Drawing.Point(500, 161);
            this.txtTimeRemaining.Name = "txtTimeRemaining";
            this.txtTimeRemaining.Size = new System.Drawing.Size(49, 13);
            this.txtTimeRemaining.TabIndex = 20;
            this.txtTimeRemaining.Text = "00:00:00";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(341, 161);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Remaining time";
            // 
            // txtTimePassed
            // 
            this.txtTimePassed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimePassed.AutoSize = true;
            this.txtTimePassed.Location = new System.Drawing.Point(500, 143);
            this.txtTimePassed.Name = "txtTimePassed";
            this.txtTimePassed.Size = new System.Drawing.Size(49, 13);
            this.txtTimePassed.TabIndex = 19;
            this.txtTimePassed.Text = "00:00:00";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(341, 143);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Total time";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.txtSecondGroupCount);
            this.panel1.Controls.Add(this.txtTimeRemaining);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.btnSliceFolder);
            this.panel1.Controls.Add(this.txtFirstGroupCount);
            this.panel1.Controls.Add(this.txtProjectionTimeMs);
            this.panel1.Controls.Add(this.txtProjectionTimeMsSecondGroup);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtProjectionTimeMsFirstGroup);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtFolder);
            this.panel1.Controls.Add(this.txtTimePassed);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.pbLayerThumbnail);
            this.panel1.Controls.Add(this.txtTotalSlices);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCurrentSlice);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 390);
            this.panel1.TabIndex = 29;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Image = global::Controller.Properties.Resources.glyphicons_265_electrical_plug;
            this.btnConnect.Location = new System.Drawing.Point(299, 34);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnConnect.Size = new System.Drawing.Size(80, 69);
            this.btnConnect.TabIndex = 29;
            this.btnConnect.Text = "Connect";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Enabled = false;
            this.btnStart.Image = global::Controller.Properties.Resources.glyphicons_173_play;
            this.btnStart.Location = new System.Drawing.Point(471, 34);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 69);
            this.btnStart.TabIndex = 8;
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.Enabled = false;
            this.btnPause.Image = global::Controller.Properties.Resources.glyphicons_174_pause;
            this.btnPause.Location = new System.Drawing.Point(385, 34);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(80, 69);
            this.btnPause.TabIndex = 7;
            this.btnPause.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPause.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // pbLayerThumbnail
            // 
            this.pbLayerThumbnail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLayerThumbnail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLayerThumbnail.Location = new System.Drawing.Point(344, 231);
            this.pbLayerThumbnail.Name = "pbLayerThumbnail";
            this.pbLayerThumbnail.Size = new System.Drawing.Size(205, 144);
            this.pbLayerThumbnail.TabIndex = 0;
            this.pbLayerThumbnail.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.btnEmergencyStop);
            this.panel2.Controls.Add(this.btnDrainReservoir);
            this.panel2.Controls.Add(this.btnInkPump);
            this.panel2.Controls.Add(this.btnLiftDown);
            this.panel2.Controls.Add(this.btnLiftUp);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.ledEmptyVat);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.ledInkPump);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.ledBottomSensor);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.lblPositionFromTopMm);
            this.panel2.Controls.Add(this.ledTopSensor);
            this.panel2.Location = new System.Drawing.Point(567, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 390);
            this.panel2.TabIndex = 30;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label20.Location = new System.Drawing.Point(3, 196);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(114, 18);
            this.label20.TabIndex = 17;
            this.label20.Text = "Manual controls";
            // 
            // btnEmergencyStop
            // 
            this.btnEmergencyStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmergencyStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmergencyStop.ForeColor = System.Drawing.Color.White;
            this.btnEmergencyStop.Image = global::Controller.Properties.Resources.emergency_stop;
            this.btnEmergencyStop.Location = new System.Drawing.Point(54, 223);
            this.btnEmergencyStop.Name = "btnEmergencyStop";
            this.btnEmergencyStop.Size = new System.Drawing.Size(156, 154);
            this.btnEmergencyStop.TabIndex = 16;
            this.btnEmergencyStop.Text = "EMERGENCY\r\nSTOP";
            this.btnEmergencyStop.UseVisualStyleBackColor = true;
            this.btnEmergencyStop.Click += new System.EventHandler(this.btnEmergencyStop_Click);
            // 
            // btnDrainReservoir
            // 
            this.btnDrainReservoir.Image = global::Controller.Properties.Resources.drain;
            this.btnDrainReservoir.Location = new System.Drawing.Point(0, 343);
            this.btnDrainReservoir.Name = "btnDrainReservoir";
            this.btnDrainReservoir.Size = new System.Drawing.Size(48, 34);
            this.btnDrainReservoir.TabIndex = 15;
            this.btnDrainReservoir.UseVisualStyleBackColor = true;
            // 
            // btnInkPump
            // 
            this.btnInkPump.Image = global::Controller.Properties.Resources.fill;
            this.btnInkPump.Location = new System.Drawing.Point(0, 303);
            this.btnInkPump.Name = "btnInkPump";
            this.btnInkPump.Size = new System.Drawing.Size(48, 34);
            this.btnInkPump.TabIndex = 14;
            this.btnInkPump.UseVisualStyleBackColor = true;
            // 
            // btnLiftDown
            // 
            this.btnLiftDown.Image = global::Controller.Properties.Resources.glyphicons_212_down_arrow;
            this.btnLiftDown.Location = new System.Drawing.Point(0, 263);
            this.btnLiftDown.Name = "btnLiftDown";
            this.btnLiftDown.Size = new System.Drawing.Size(48, 34);
            this.btnLiftDown.TabIndex = 13;
            this.btnLiftDown.UseVisualStyleBackColor = true;
            // 
            // btnLiftUp
            // 
            this.btnLiftUp.Image = global::Controller.Properties.Resources.glyphicons_213_up_arrow;
            this.btnLiftUp.Location = new System.Drawing.Point(0, 223);
            this.btnLiftUp.Name = "btnLiftUp";
            this.btnLiftUp.Size = new System.Drawing.Size(48, 34);
            this.btnLiftUp.TabIndex = 12;
            this.btnLiftUp.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 161);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "Empty vat valve";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ledEmptyVat
            // 
            this.ledEmptyVat.BackgroundImage = global::Controller.Properties.Resources.led_off;
            this.ledEmptyVat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ledEmptyVat.Location = new System.Drawing.Point(179, 155);
            this.ledEmptyVat.Name = "ledEmptyVat";
            this.ledEmptyVat.Size = new System.Drawing.Size(26, 27);
            this.ledEmptyVat.TabIndex = 10;
            this.ledEmptyVat.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 128);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 8;
            this.label19.Text = "Ink pump";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ledInkPump
            // 
            this.ledInkPump.BackgroundImage = global::Controller.Properties.Resources.led_off;
            this.ledInkPump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ledInkPump.Location = new System.Drawing.Point(179, 122);
            this.ledInkPump.Name = "ledInkPump";
            this.ledInkPump.Size = new System.Drawing.Size(26, 27);
            this.ledInkPump.TabIndex = 9;
            this.ledInkPump.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Bottom sensor";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ledBottomSensor
            // 
            this.ledBottomSensor.BackgroundImage = global::Controller.Properties.Resources.led_off;
            this.ledBottomSensor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ledBottomSensor.Location = new System.Drawing.Point(179, 89);
            this.ledBottomSensor.Name = "ledBottomSensor";
            this.ledBottomSensor.Size = new System.Drawing.Size(26, 27);
            this.ledBottomSensor.TabIndex = 6;
            this.ledBottomSensor.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Lift position (from top in mm)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 62);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Top sensor";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label16.Location = new System.Drawing.Point(3, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 18);
            this.label16.TabIndex = 2;
            this.label16.Text = "Printer status";
            // 
            // lblPositionFromTopMm
            // 
            this.lblPositionFromTopMm.Location = new System.Drawing.Point(164, 33);
            this.lblPositionFromTopMm.Name = "lblPositionFromTopMm";
            this.lblPositionFromTopMm.Size = new System.Drawing.Size(46, 17);
            this.lblPositionFromTopMm.TabIndex = 1;
            this.lblPositionFromTopMm.Text = "-1";
            this.lblPositionFromTopMm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ledTopSensor
            // 
            this.ledTopSensor.BackgroundImage = global::Controller.Properties.Resources.led_off;
            this.ledTopSensor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ledTopSensor.Location = new System.Drawing.Point(179, 56);
            this.ledTopSensor.Name = "ledTopSensor";
            this.ledTopSensor.Size = new System.Drawing.Size(26, 27);
            this.ledTopSensor.TabIndex = 5;
            this.ledTopSensor.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 412);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "Main";
            this.Text = "Portobello Print Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLayerThumbnail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledEmptyVat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledInkPump)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBottomSensor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTopSensor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog sliceFolderDlg;
        private System.Windows.Forms.PictureBox pbLayerThumbnail;
        private System.Windows.Forms.Button btnSliceFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox txtProjectionTimeMs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtCurrentSlice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtTotalSlices;
        private System.Windows.Forms.TextBox txtProjectionTimeMsFirstGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProjectionTimeMsSecondGroup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFirstGroupCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSecondGroupCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label txtTimeRemaining;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label txtTimePassed;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardwareConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulatePrinterToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblPositionFromTopMm;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox ledTopSensor;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox ledEmptyVat;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox ledInkPump;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox ledBottomSensor;
        private System.Windows.Forms.Button btnLiftUp;
        private System.Windows.Forms.Button btnEmergencyStop;
        private System.Windows.Forms.Button btnDrainReservoir;
        private System.Windows.Forms.Button btnInkPump;
        private System.Windows.Forms.Button btnLiftDown;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnConnect;

    }
}