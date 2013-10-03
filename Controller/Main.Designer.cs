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
            ((System.ComponentModel.ISupportInitialize)(this.pbLayerThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSliceFolder
            // 
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
            this.txtFolder.Location = new System.Drawing.Point(151, 10);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(343, 20);
            this.txtFolder.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(467, 37);
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
            this.txtStatus.Size = new System.Drawing.Size(315, 144);
            this.txtStatus.TabIndex = 5;
            this.txtStatus.WordWrap = false;
            // 
            // pbLayerThumbnail
            // 
            this.pbLayerThumbnail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLayerThumbnail.Location = new System.Drawing.Point(337, 99);
            this.pbLayerThumbnail.Name = "pbLayerThumbnail";
            this.pbLayerThumbnail.Size = new System.Drawing.Size(205, 144);
            this.pbLayerThumbnail.TabIndex = 0;
            this.pbLayerThumbnail.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 255);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSliceFolder);
            this.Controls.Add(this.pbLayerThumbnail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Portobello Print Controller";
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

    }
}