using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder.pnlBottomDisplay
{
   public class TabControlPOSC
    {
        protected TabControl _tabControlPO;
        public TabControl tabControlPO => _tabControlPO;

        public TabControlPOSC()
        {
            this._tabControlPO = frmMain_Control.Instance.tabControlPO;
        }
    }
}
