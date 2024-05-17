using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlOrderPurchasing.pnlSettingOrderPurchasing.grbSettingOrderPurchasing;
using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlOrderPurchasing.pnlSettingOrderPurchasing
{
    public class PanelSettingOrderPurchasingSC
    {
        protected GrbSettingOrderPurchasingSC _GrbSettingOrderPurchasingSC;

        protected Panel _pnlSettingOrderPurchasing;
        public Panel PnlSettingOrderPurchasing => _pnlSettingOrderPurchasing;
        public PanelSettingOrderPurchasingSC()
        {
            this._GrbSettingOrderPurchasingSC = new GrbSettingOrderPurchasingSC();
            this._pnlSettingOrderPurchasing = frmDetailCustomer.Instance.pnlSettingOrderPurchasing;

        }


    }
}
