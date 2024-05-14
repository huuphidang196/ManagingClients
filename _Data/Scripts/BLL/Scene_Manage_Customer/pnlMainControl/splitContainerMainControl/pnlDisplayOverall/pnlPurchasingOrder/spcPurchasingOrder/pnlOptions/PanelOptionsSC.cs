using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder.pnlOptions.pnlBottomOption;
using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder.pnlOptions.pnlHeaderOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder.pnlOptions
{
    public class PanelOptionsSC
    {
        protected SplitContainerOrderSC _SplitContainerOrderSC;
        public SplitContainerOrderSC SplitContainerOrderSC => _SplitContainerOrderSC;

        protected PanelHeaderOptionSC _PanelHeaderOptionSC;
        public PanelHeaderOptionSC PanelHeaderOptionSC => _PanelHeaderOptionSC;

        protected PanelBottomOption _PanelBottomOption;
        public PanelBottomOption PanelBottomOption => _PanelBottomOption;

        public PanelOptionsSC(SplitContainerOrderSC splitContainerOrderSC)
        {
            this._SplitContainerOrderSC = splitContainerOrderSC;

            this._PanelHeaderOptionSC = new PanelHeaderOptionSC();
            this._PanelBottomOption = new PanelBottomOption(this);
        }

    }
}
