using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder.pnlBottomDisplay.TabControlPO.TabControlPODSKH
{
    public class TabControlDSKHSC
    {
        public DataGridView _dgvDisplayAllCusPO;
        public DataGridView dgvDisplayAllCusPO => _dgvDisplayAllCusPO;

        public TabControlDSKHSC()
        {
            this._dgvDisplayAllCusPO = frmMain_Control.Instance.dgvDisplayAllCusPO;
        }
    }
}
