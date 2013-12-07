namespace TestStepperDrive
{
    partial class Form1
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
            this.txtPulses = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDirUp = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPulses
            // 
            this.txtPulses.Location = new System.Drawing.Point(148, 12);
            this.txtPulses.Name = "txtPulses";
            this.txtPulses.Size = new System.Drawing.Size(100, 20);
            this.txtPulses.TabIndex = 0;
            this.txtPulses.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Micrometer";
            // 
            // cbDirUp
            // 
            this.cbDirUp.AutoSize = true;
            this.cbDirUp.Location = new System.Drawing.Point(148, 39);
            this.cbDirUp.Name = "cbDirUp";
            this.cbDirUp.Size = new System.Drawing.Size(85, 17);
            this.cbDirUp.TabIndex = 2;
            this.cbDirUp.Text = "Direction Up";
            this.cbDirUp.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 121);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbDirUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPulses);
            this.Name = "Form1";
            this.Text = "Test Stepper Drive";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPulses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbDirUp;
        private System.Windows.Forms.Button button1;
    }
}

