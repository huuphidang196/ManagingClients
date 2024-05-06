using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.SplitDisplayFinderOverall;
using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.SplitDisplayFinderOverall.PanelDisplayOverall;
using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.SplitDisplayFinderOverall.PanelDisplayOverall.PanelDetailProfile;
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

        protected SplitDisplayFinderOverallManager _SplitDisplayFinderOverall;

        public frmMain_Control()
        {
            InitializeComponent();

            this.SetAllValue();
        }

        protected virtual void SetAllValue()
        {
            this._SplitDisplayFinderOverall = new SplitDisplayFinderOverallManager(this, this.pnlDisplayOverall, this.pnlDetailProfile
              , this.pnlPurchasingOrder);
        }

        private void frmMain_Control_Load(object sender, EventArgs e)
        {
            PanelDisplayOverallSC.Instance.TurnOnPanelProfileAccount();

        }

        private void btnPurchasingOrder_Click(object sender, EventArgs e)
        {
            PanelDisplayOverallSC.Instance.TurnOnPanelPurchasingOrder();
        }

        private void btnProfileAccount_Click(object sender, EventArgs e)
        {
            PanelDisplayOverallSC.Instance.TurnOnPanelProfileAccount();
        }

        private void btnSavePAC_Click(object sender, EventArgs e)
        {
            TabControlMyProfileDetail.Instance.SaveMyProfile();
        }
    }
}
