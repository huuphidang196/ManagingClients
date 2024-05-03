using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.SplitDisplayFinderOverall;
using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.SplitDisplayFinderOverall.PanelDisplayOverall;
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
        protected SplitDisplayFinderOverall _SplitDisplayFinderOverall;
       
        public frmMain_Control()
        {
            InitializeComponent();

            this.SetAllValue();
        }

        protected virtual void SetAllValue()
        {
            this._SplitDisplayFinderOverall = new SplitDisplayFinderOverall(this.pnlDisplayOverall, this.pnlDetailProfile
              , this.pnlPurchasingOrder);
        }

        private void frmMain_Control_Load(object sender, EventArgs e)
        {
            PanelDisplayOverallSC.Instance.PanelDetail_Profile.Visible = true;
            PanelDisplayOverallSC.Instance.PanelPurchasingOrder.Visible = false;

        }

        private void btnPurchasingOrder_Click(object sender, EventArgs e)
        {
            PanelDisplayOverallSC.Instance.PanelDetail_Profile.Visible = false;
            PanelDisplayOverallSC.Instance.PanelPurchasingOrder.Visible = true;
        }

        private void btnProfileAccount_Click(object sender, EventArgs e)
        {
            PanelDisplayOverallSC.Instance.PanelDetail_Profile.Visible = true;
            PanelDisplayOverallSC.Instance.PanelPurchasingOrder.Visible = false;
        }
    }
}
