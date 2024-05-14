using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder.pnlBottomDisplay;
using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder.pnlOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder
{
    public class SplitContainerOrderSC
    {
        protected SplitContainer _spcContainerOrder;
        public SplitContainer spcContainerOrder => _spcContainerOrder;

        protected PanelBottomDisplayOrderSC _PanelBottomDisplayOrderSC;
        public PanelBottomDisplayOrderSC PanelBottomDisplayOrderSC => _PanelBottomDisplayOrderSC;

        protected PanelOptionsSC _PanelOptionsSC;
        public PanelOptionsSC PanelOptionsSC => _PanelOptionsSC;
        public SplitContainerOrderSC()
        {
            this._spcContainerOrder = frmMain_Control.Instance.spcPurchasingOrder;
            this._PanelBottomDisplayOrderSC = new PanelBottomDisplayOrderSC();
            this._PanelOptionsSC = new PanelOptionsSC(this);
        }
    }
}
