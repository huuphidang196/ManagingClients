using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder.pnlBottomDisplay
{
    public class PanelBottomDisplayOrderSC
    {
        protected Panel _pnlBottomDisplayPO;

        public Panel pnlBottomDisplayPO => _pnlBottomDisplayPO;

        protected TabControlPOSC _TabControlPOSC;
        public TabControlPOSC TabControlPOSC => _TabControlPOSC;
        public PanelBottomDisplayOrderSC()
        {
            this._pnlBottomDisplayPO = FrmMain_Control.Instance.pnlBottomDisplayPO;
            this._TabControlPOSC = new TabControlPOSC();
        }

    }
}
