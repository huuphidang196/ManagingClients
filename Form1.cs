using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl;
using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.splitContainerMainControl.pnlDisplayOverall;
using ManagingClients._Data.Scripts.DAO.Scene_Manage_Customer.pnlMainControl.pnlDisplayOverall.pnlDetailProfile;
using ManagingClients._Data.Scripts.DTO.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients
{
    public partial class frmMain_Control : Form
    {
        private static frmMain_Control _instance;
        public static frmMain_Control Instance
        {
            get
            {
                if (_instance == null) _instance = new frmMain_Control();
                return frmMain_Control._instance;
            }

            private set { frmMain_Control._instance = value; }
        }

        public const float VAT = 10;//thuế vat 

        protected ProfileAccount _ProfileAccount;
        public ProfileAccount ProfileAccount => _ProfileAccount;
        
        public virtual void SetProfileAccount(ProfileAccount profileAccount) => this._ProfileAccount = profileAccount;

        public frmMain_Control()
        {
            InitializeComponent();

            this.SetAllValue();
        }

        protected virtual void SetAllValue()
        {

        }

        private void frmMain_Control_Load(object sender, EventArgs e)
        {
           // PanelMainControl.Instance.SplitContainerMainControl.PanelDisplayOverallSC.TurnOnPanelProfileAccount();

        }
        private void btnProfileAccount_Click(object sender, EventArgs e)
        {
            PanelMainControl.Instance.SplitContainerMainControl.PanelDisplayOverallSC.TurnOnPanelProfileAccount();
        }

        private void btnPurchasingOrder_Click(object sender, EventArgs e)
        {
            PanelMainControl.Instance.SplitContainerMainControl.PanelDisplayOverallSC.TurnOnPanelPurchasingOrder();
        }

        #region Detail_Profile_Account
    
        private void btnSavePAC_Click(object sender, EventArgs e)
        {
           PanelMainControl.Instance.SplitContainerMainControl.PanelDisplayOverallSC.
                Panel_Detail_Profile.TabControlProfileDetailSC.PanelProfileAccountSC.SaveDataProfileAccount();
        }

        private void btnSelectAVT_Click(object sender, EventArgs e)
        {
            PanelMainControl.Instance.SplitContainerMainControl.PanelDisplayOverallSC.
                Panel_Detail_Profile.TabControlProfileDetailSC.PanelProfileAccountSC.ProcessEventButtonSelectAvatarClick();
        }

        #endregion

        private void tabControlPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelMainControl.Instance.SplitContainerMainControl.PanelDisplayOverallSC.PanelPurchasingOrder.
                SplitContainerOrderSC.PanelBottomDisplayOrderSC.TabControlPOSC.ProcessTabControlPurchasingOrderSelectedChange();
        }
    }
}
