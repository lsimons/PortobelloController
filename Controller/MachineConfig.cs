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
            this.txtDipHeightUM.Text = DipDepthMu.ToString();
            this.txtInitializeHeightUM.Text = InitializePositionFromTopSensorMu.ToString();
        }

        public int DipDepthMu
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

        public int LayerHeightMu
        {
            get
            {
                var layerHeight = baseRegKey.GetValue("LayerHeightMu");
                if (layerHeight == null) {
                    baseRegKey.SetValue("LayerHeightMu", 60, RegistryValueKind.DWord);
                    layerHeight = 60;
                }
                return (int)layerHeight;
            }
        }

        public int InitializePositionFromTopSensorMu
        {
            get
            {
                var initializeHeighMu = baseRegKey.GetValue("InitializeHeightFromTopMu");
                if (initializeHeighMu == null) {
                    baseRegKey.SetValue("InitializeHeightFromTopMu", 50000, RegistryValueKind.DWord);
                    initializeHeighMu = 50000;
                }
                return (int)initializeHeighMu;
            }
            set
            {
                baseRegKey.SetValue("InitializeHeightFromTopMu", value, RegistryValueKind.DWord);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            int dipHeight;
            if (int.TryParse(this.txtDipHeightUM.Text, out dipHeight)) {
                this.DipDepthMu = dipHeight;
            }
            int initializeHeight;
            if (int.TryParse(this.txtInitializeHeightUM.Text, out initializeHeight)) {
                this.InitializePositionFromTopSensorMu = initializeHeight;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
