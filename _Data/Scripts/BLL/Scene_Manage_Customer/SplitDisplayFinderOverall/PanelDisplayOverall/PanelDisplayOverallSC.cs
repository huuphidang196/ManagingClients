using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.SplitDisplayFinderOverall.PanelDisplayOverall
{
    public class PanelDisplayOverallSC
    {
        private static PanelDisplayOverallSC _instance;
        public static PanelDisplayOverallSC Instance => _instance;

        protected Panel _pnlDetail_Profile;
        public Panel PanelDetail_Profile => _pnlDetail_Profile;

        protected Panel _pnlPurchasing_Order;
        public Panel PanelPurchasingOrder => _pnlPurchasing_Order;

        public PanelDisplayOverallSC()
        {
            _instance = this;
        }

        public virtual void SetAllPanelInSidePanelDisplayOverall(Panel pnlDetailProfile, Panel pnlPurchasing_Order)
        {
            //Panel Display Detail Profile
            this._pnlDetail_Profile = pnlDetailProfile;

            this._pnlPurchasing_Order = pnlPurchasing_Order;
        }

    }
}
