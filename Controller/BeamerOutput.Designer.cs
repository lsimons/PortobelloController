namespace Controller
{
    partial class BeamerOutput
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
            this.pbFront = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFront)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFront
            // 
            this.pbFront.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbFront.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFront.InitialImage = null;
            this.pbFront.Location = new System.Drawing.Point(0, 0);
            this.pbFront.Name = "pbFront";
            this.pbFront.Size = new System.Drawing.Size(606, 469);
            this.pbFront.TabIndex = 0;
            this.pbFront.TabStop = false;
            // 
            // BeamerOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(606, 469);
            this.Controls.Add(this.pbFront);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BeamerOutput";
            this.Text = "Beamer Output Window";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BeamerOutput_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbFront)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFront;
    }
}

