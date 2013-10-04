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
            ((System.ComponentModel.ISupportInitialize)(this.pbLayerThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSliceFolder
            // 
            this.btnSliceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSliceFolder.Location = new System.Drawing.Point(500, 8);
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
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Slice folder";
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(151, 10);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(343, 20);
            this.txtFolder.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(467, 36);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 52);
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
            this.txtStatus.Location = new System.Drawing.Point(12, 99);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(315, 176);
            this.txtStatus.TabIndex = 5;
            this.txtStatus.WordWrap = false;
            // 
            // pbLayerThumbnail
            // 
            this.pbLayerThumbnail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLayerThumbnail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbLayerThumbnail.Location = new System.Drawing.Point(337, 131);
            this.pbLayerThumbnail.Name = "pbLayerThumbnail";
            this.pbLayerThumbnail.Size = new System.Drawing.Size(205, 144);
            this.pbLayerThumbnail.TabIndex = 0;
            this.pbLayerThumbnail.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Projection time (ms)";
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.Location = new System.Drawing.Point(386, 36);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 52);
            this.btnPause.TabIndex = 8;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(16, 70);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(311, 23);
            this.progressBar.TabIndex = 9;
            // 
            // txtProjectionTimeMs
            // 
            this.txtProjectionTimeMs.Location = new System.Drawing.Point(151, 36);
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
            this.label3.Location = new System.Drawing.Point(334, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Slices";
            // 
            // txtCurrentSlice
            // 
            this.txtCurrentSlice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentSlice.AutoSize = true;
            this.txtCurrentSlice.Location = new System.Drawing.Point(448, 102);
            this.txtCurrentSlice.Name = "txtCurrentSlice";
            this.txtCurrentSlice.Size = new System.Drawing.Size(43, 13);
            this.txtCurrentSlice.TabIndex = 12;
            this.txtCurrentSlice.Text = "000000";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(489, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "/";
            // 
            // txtTotalSlices
            // 
            this.txtTotalSlices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalSlices.AutoSize = true;
            this.txtTotalSlices.Location = new System.Drawing.Point(499, 102);
            this.txtTotalSlices.Name = "txtTotalSlices";
            this.txtTotalSlices.Size = new System.Drawing.Size(43, 13);
            this.txtTotalSlices.TabIndex = 14;
            this.txtTotalSlices.Text = "000000";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 287);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(570, 325);
            this.Name = "Main";
            this.Text = "Portobello Print Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbLayerThumbnail)).EndInit();
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

    }
}