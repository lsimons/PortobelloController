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
            this.btnStart = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pbLayerThumbnail = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
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
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTimeRemaining = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTimePassed = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.simulatePrinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.pbLayerThumbnail)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSliceFolder
            // 
            this.btnSliceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSliceFolder.Location = new System.Drawing.Point(500, 25);
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
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Slice folder";
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(148, 27);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(343, 20);
            this.txtFolder.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(448, 53);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(94, 69);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Location = new System.Drawing.Point(9, 157);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(315, 208);
            this.txtStatus.TabIndex = 5;
            this.txtStatus.WordWrap = false;
            // 
            // pbLayerThumbnail
            // 
            this.pbLayerThumbnail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLayerThumbnail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLayerThumbnail.Location = new System.Drawing.Point(337, 219);
            this.pbLayerThumbnail.Name = "pbLayerThumbnail";
            this.pbLayerThumbnail.Size = new System.Drawing.Size(205, 144);
            this.pbLayerThumbnail.TabIndex = 0;
            this.pbLayerThumbnail.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Projection time (ms)";
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.Location = new System.Drawing.Point(348, 53);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(94, 69);
            this.btnPause.TabIndex = 8;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(9, 128);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(533, 23);
            this.progressBar.TabIndex = 9;
            // 
            // txtProjectionTimeMs
            // 
            this.txtProjectionTimeMs.Location = new System.Drawing.Point(148, 102);
            this.txtProjectionTimeMs.Name = "txtProjectionTimeMs";
            this.txtProjectionTimeMs.Size = new System.Drawing.Size(48, 20);
            this.txtProjectionTimeMs.TabIndex = 10;
            this.txtProjectionTimeMs.Text = "1000";
            this.txtProjectionTimeMs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProjectionTimeMs.TextChanged += new System.EventHandler(this.txtProjectionTimeMs_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Slices";
            // 
            // txtCurrentSlice
            // 
            this.txtCurrentSlice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentSlice.AutoSize = true;
            this.txtCurrentSlice.Location = new System.Drawing.Point(448, 203);
            this.txtCurrentSlice.Name = "txtCurrentSlice";
            this.txtCurrentSlice.Size = new System.Drawing.Size(43, 13);
            this.txtCurrentSlice.TabIndex = 12;
            this.txtCurrentSlice.Text = "000000";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(489, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "/";
            // 
            // txtTotalSlices
            // 
            this.txtTotalSlices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalSlices.AutoSize = true;
            this.txtTotalSlices.Location = new System.Drawing.Point(499, 203);
            this.txtTotalSlices.Name = "txtTotalSlices";
            this.txtTotalSlices.Size = new System.Drawing.Size(43, 13);
            this.txtTotalSlices.TabIndex = 14;
            this.txtTotalSlices.Text = "000000";
            // 
            // txtProjectionTimeMsFirstGroup
            // 
            this.txtProjectionTimeMsFirstGroup.Location = new System.Drawing.Point(148, 50);
            this.txtProjectionTimeMsFirstGroup.Name = "txtProjectionTimeMsFirstGroup";
            this.txtProjectionTimeMsFirstGroup.Size = new System.Drawing.Size(48, 20);
            this.txtProjectionTimeMsFirstGroup.TabIndex = 16;
            this.txtProjectionTimeMsFirstGroup.Text = "0";
            this.txtProjectionTimeMsFirstGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProjectionTimeMsFirstGroup.TextChanged += new System.EventHandler(this.txtProjectionTimeMsFirstGroup_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Projection time (ms)";
            // 
            // txtProjectionTimeMsSecondGroup
            // 
            this.txtProjectionTimeMsSecondGroup.Location = new System.Drawing.Point(148, 76);
            this.txtProjectionTimeMsSecondGroup.Name = "txtProjectionTimeMsSecondGroup";
            this.txtProjectionTimeMsSecondGroup.Size = new System.Drawing.Size(48, 20);
            this.txtProjectionTimeMsSecondGroup.TabIndex = 18;
            this.txtProjectionTimeMsSecondGroup.Text = "0";
            this.txtProjectionTimeMsSecondGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProjectionTimeMsSecondGroup.TextChanged += new System.EventHandler(this.txtProjectionTimeMsSecondGroup_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Projection time (ms)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(202, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "for";
            // 
            // txtFirstGroupCount
            // 
            this.txtFirstGroupCount.Location = new System.Drawing.Point(227, 50);
            this.txtFirstGroupCount.Name = "txtFirstGroupCount";
            this.txtFirstGroupCount.Size = new System.Drawing.Size(33, 20);
            this.txtFirstGroupCount.TabIndex = 20;
            this.txtFirstGroupCount.Text = "0";
            this.txtFirstGroupCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFirstGroupCount.TextChanged += new System.EventHandler(this.txtFirstGroupCount_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(266, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "layers";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(266, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "layers";
            // 
            // txtSecondGroupCount
            // 
            this.txtSecondGroupCount.Location = new System.Drawing.Point(227, 79);
            this.txtSecondGroupCount.Name = "txtSecondGroupCount";
            this.txtSecondGroupCount.Size = new System.Drawing.Size(33, 20);
            this.txtSecondGroupCount.TabIndex = 23;
            this.txtSecondGroupCount.Text = "0";
            this.txtSecondGroupCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSecondGroupCount.TextChanged += new System.EventHandler(this.txtSecondGroupCount_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(202, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "for";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(202, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "for remaining layers";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(554, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.simulatePrinterToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
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
            // 
            // txtTimeRemaining
            // 
            this.txtTimeRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimeRemaining.AutoSize = true;
            this.txtTimeRemaining.Location = new System.Drawing.Point(493, 180);
            this.txtTimeRemaining.Name = "txtTimeRemaining";
            this.txtTimeRemaining.Size = new System.Drawing.Size(49, 13);
            this.txtTimeRemaining.TabIndex = 30;
            this.txtTimeRemaining.Text = "00:00:00";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(334, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Remaining time";
            // 
            // txtTimePassed
            // 
            this.txtTimePassed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimePassed.AutoSize = true;
            this.txtTimePassed.Location = new System.Drawing.Point(493, 160);
            this.txtTimePassed.Name = "txtTimePassed";
            this.txtTimePassed.Size = new System.Drawing.Size(49, 13);
            this.txtTimePassed.TabIndex = 28;
            this.txtTimePassed.Text = "00:00:00";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(334, 160);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Total time";
            // 
            // simulatePrinterToolStripMenuItem
            // 
            this.simulatePrinterToolStripMenuItem.Name = "simulatePrinterToolStripMenuItem";
            this.simulatePrinterToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.simulatePrinterToolStripMenuItem.Text = "Simulate printer";
            this.simulatePrinterToolStripMenuItem.Click += new System.EventHandler(this.simulatePrinterToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 375);
            this.Controls.Add(this.txtTimeRemaining);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTimePassed);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSecondGroupCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFirstGroupCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtProjectionTimeMsSecondGroup);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtProjectionTimeMsFirstGroup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalSlices);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCurrentSlice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProjectionTimeMs);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSliceFolder);
            this.Controls.Add(this.pbLayerThumbnail);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(570, 325);
            this.Name = "Main";
            this.Text = "Portobello Print Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLayerThumbnail)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem simulatePrinterToolStripMenuItem;

    }
}