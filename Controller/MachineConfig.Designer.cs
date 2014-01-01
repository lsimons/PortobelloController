namespace Controller
{
    partial class MachineConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineConfig));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtDipHeightUM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInitializeHeightUM = new System.Windows.Forms.TextBox();
            this.cbLayerThickness = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResinPumpAfterInitializeSeconds = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(212, 118);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(293, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDipHeightUM
            // 
            this.txtDipHeightUM.Location = new System.Drawing.Point(194, 12);
            this.txtDipHeightUM.Name = "txtDipHeightUM";
            this.txtDipHeightUM.Size = new System.Drawing.Size(174, 20);
            this.txtDipHeightUM.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dip height (mu)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Initialize height (mu)";
            // 
            // txtInitializeHeightUM
            // 
            this.txtInitializeHeightUM.Location = new System.Drawing.Point(194, 38);
            this.txtInitializeHeightUM.Name = "txtInitializeHeightUM";
            this.txtInitializeHeightUM.Size = new System.Drawing.Size(174, 20);
            this.txtInitializeHeightUM.TabIndex = 4;
            // 
            // cbLayerThickness
            // 
            this.cbLayerThickness.FormattingEnabled = true;
            this.cbLayerThickness.Items.AddRange(new object[] {
            "30",
            "60",
            "88",
            "100"});
            this.cbLayerThickness.Location = new System.Drawing.Point(194, 64);
            this.cbLayerThickness.Name = "cbLayerThickness";
            this.cbLayerThickness.Size = new System.Drawing.Size(174, 21);
            this.cbLayerThickness.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Layer thickness (mu)";
            // 
            // txtResinPumpAfterInitializeSeconds
            // 
            this.txtResinPumpAfterInitializeSeconds.Location = new System.Drawing.Point(194, 91);
            this.txtResinPumpAfterInitializeSeconds.Name = "txtResinPumpAfterInitializeSeconds";
            this.txtResinPumpAfterInitializeSeconds.Size = new System.Drawing.Size(174, 20);
            this.txtResinPumpAfterInitializeSeconds.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Resin pump after initialize (seconds)";
            // 
            // MachineConfig
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(380, 153);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtResinPumpAfterInitializeSeconds);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbLayerThickness);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInitializeHeightUM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDipHeightUM);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(396, 191);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(396, 191);
            this.Name = "MachineConfig";
            this.Text = "Machine Config";
            this.Load += new System.EventHandler(this.MachineConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtDipHeightUM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInitializeHeightUM;
        private System.Windows.Forms.ComboBox cbLayerThickness;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResinPumpAfterInitializeSeconds;
        private System.Windows.Forms.Label label4;
    }
}