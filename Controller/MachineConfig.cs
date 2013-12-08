using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
{
    public partial class MachineConfig : Form
    {
        private RegistryKey baseRegKey;

        public MachineConfig()
        {
            InitializeComponent();
            baseRegKey = Registry.CurrentUser.CreateSubKey("PortobelloController");
        }

        private void MachineConfig_Load(object sender, EventArgs e)
        {
            this.txtDipHeightUM.Text = CurrentDipValue.ToString();
        }

        public int CurrentDipValue
        {
            get
            {
                var currentDipValue = baseRegKey.GetValue("DipHeightMu");
                if (currentDipValue == null) {
                    baseRegKey.SetValue("DipHeightMu", 3000, RegistryValueKind.DWord);
                    currentDipValue = 3000;
                }
                return (int)currentDipValue;
            }
            set
            {
                baseRegKey.SetValue("DipHeightMu", value, RegistryValueKind.DWord);
            }
        }

        public int LayerHeight
        {
            get
            {
                var currentDipValue = baseRegKey.GetValue("LayerHeightMu");
                if (currentDipValue == null) {
                    baseRegKey.SetValue("LayerHeightMu", 60, RegistryValueKind.DWord);
                    currentDipValue = 60;
                }
                return (int)currentDipValue;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            int dipHeight;
            if (int.TryParse(this.txtDipHeightUM.Text, out dipHeight)) {
                this.CurrentDipValue = dipHeight;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
