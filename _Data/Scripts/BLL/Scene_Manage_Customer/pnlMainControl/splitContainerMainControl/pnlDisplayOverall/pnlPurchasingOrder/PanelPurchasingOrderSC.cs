using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder
{
    public class PanelPurchasingOrderSC
    {
        protected Panel _pnlPurchasing_Order;
        public Panel PanelPurchasingOrder => _pnlPurchasing_Order;

        protected SplitContainerOrderSC _SplitContainerOrderSC;
        public SplitContainerOrderSC SplitContainerOrderSC => _SplitContainerOrderSC;

        public PanelPurchasingOrderSC()
        {
            this._pnlPurchasing_Order = frmMain_Control.Instance.pnlPurchasingOrder;
            this._SplitContainerOrderSC = new SplitContainerOrderSC();
        }
    }
}
