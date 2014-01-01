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
            baseRegKey = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("Orchis Print Solutions").CreateSubKey("Portobello Controller");
        }

        private void MachineConfig_Load(object sender, EventArgs e)
        {
            this.txtDipHeightUM.Text = this.DipDepthMu.ToString();
            this.txtInitializeHeightUM.Text = this.InitializePositionFromTopSensorMu.ToString();
            this.cbLayerThickness.SelectedItem = this.LayerHeightMu.ToString();
            this.txtResinPumpAfterInitializeSeconds.Text = this.PumpTimeAfterInitializeSeconds.ToString();
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
            set
            {
                baseRegKey.SetValue("LayerHeightMu", value, RegistryValueKind.DWord);
            }
        }

        public int InitializePositionFromTopSensorMu
        {
            get
            {
                var initializeHeighMu = baseRegKey.GetValue("InitializeHeightFromTopMu");
                if (initializeHeighMu == null) {
                    baseRegKey.SetValue("InitializeHeightFromTopMu", 24000, RegistryValueKind.DWord);
                    initializeHeighMu = 24000;
                }
                return (int)initializeHeighMu;
            }
            set
            {
                baseRegKey.SetValue("InitializeHeightFromTopMu", value, RegistryValueKind.DWord);
            }
        }

        public int PumpTimeAfterInitializeSeconds
        {
            get
            {
                var pumpTimeAfterInitializeSeconds = baseRegKey.GetValue("PumpTimeAfterInitializeSeconds");
                if (pumpTimeAfterInitializeSeconds == null) {
                    baseRegKey.SetValue("PumpTimeAfterInitializeSeconds", 10, RegistryValueKind.DWord);
                    pumpTimeAfterInitializeSeconds = 10;
                }
                return (int)pumpTimeAfterInitializeSeconds;
            }
            set
            {
                baseRegKey.SetValue("PumpTimeAfterInitializeSeconds", value, RegistryValueKind.DWord);
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
            if (!string.IsNullOrWhiteSpace(this.cbLayerThickness.Text)) {
                this.LayerHeightMu = int.Parse(this.cbLayerThickness.Text);
            }
            int resinPumpDelay;
            if (int.TryParse(this.txtResinPumpAfterInitializeSeconds.Text, out resinPumpDelay)) {
                this.PumpTimeAfterInitializeSeconds = resinPumpDelay;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
