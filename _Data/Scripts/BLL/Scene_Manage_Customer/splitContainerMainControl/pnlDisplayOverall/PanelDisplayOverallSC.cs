using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.splitContainerMainControl.pnlDisplayOverall.pnlDetailProfile;
using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.splitContainerMainControl.pnlDisplayOverall
{
    public class PanelDisplayOverallSC
    {
        private static PanelDisplayOverallSC _instance;
        public static PanelDisplayOverallSC Instance
        {
            get
            {
                if (_instance == null) _instance = new PanelDisplayOverallSC();
                return PanelDisplayOverallSC._instance;
            }

            private set { PanelDisplayOverallSC._instance = value; }
        }

        private PanelDisplayOverallSC() 
        {
            //Panel Display Detail Profile
            this._PanelDetailProfileSC = new PanelDetailProfileSC();

            this._PanelPurchasingOrder = new PanelPurchasingOrderSC();
        }


        protected PanelDetailProfileSC _PanelDetailProfileSC;
        public PanelDetailProfileSC Panel_Detail_Profile => _PanelDetailProfileSC;

        protected PanelPurchasingOrderSC _PanelPurchasingOrder;
        public PanelPurchasingOrderSC PanelPurchasingOrder => _PanelPurchasingOrder;

  

        public virtual void TurnOnPanelProfileAccount()
        {
            this.Panel_Detail_Profile.PanelDetail_Profile.Visible = true;
            this.PanelPurchasingOrder.PanelPurchasingOrder.Visible = false;
        }
        public virtual void TurnOnPanelPurchasingOrder()
        {
            this.Panel_Detail_Profile.PanelDetail_Profile.Visible = false;
            this.PanelPurchasingOrder.PanelPurchasingOrder.Visible = true;
        }
    }
}
