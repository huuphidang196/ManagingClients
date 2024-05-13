using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder.pnlBottomDisplay.TabControlPO.TabControlPODSKH;
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
        public TabControl TabControlPO => _tabControlPO;

        protected TabControlDSKHSC _TabControlDSKHSC;
        public TabControlDSKHSC TabControlDSKHSC => _TabControlDSKHSC;

        public TabControlPOSC()
        {
            this._tabControlPO = frmMain_Control.Instance.tabControlPO;
           
            this._tabControlPO.SelectedIndex = 0;
            this._TabControlDSKHSC = new TabControlDSKHSC();

        }

        public virtual void ProcessTabControlPurchasingOrderSelectedChange()
        {
            switch (this._tabControlPO.SelectedIndex)
            {
                case 0:
                    this._TabControlDSKHSC.ShowAllListCustomer();
                    break;
                default:
                    break;
            }
        }
    }
}
