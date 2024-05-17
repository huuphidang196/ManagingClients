using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlInqueryContract;
using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlOrderPurchasing.pnlSettingOrderPurchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlOrderPurchasing
{
    public class PanelOrderPurchasingCustomerSC
    {
        protected Panel _pnlOrderPurchasingCustomerParent;
        
        protected PanelInqueryContractSC _PanelInqueryContractSC;
        public PanelInqueryContractSC PanelInqueryContractSC => _PanelInqueryContractSC;

        protected PanelSettingOrderPurchasingSC _PanelSettingOrderPurchasingSC;
        public PanelSettingOrderPurchasingSC PanelSettingOrderPurchasingSC => _PanelSettingOrderPurchasingSC;
        public PanelOrderPurchasingCustomerSC()
        {
            this._pnlOrderPurchasingCustomerParent = frmDetailCustomer.Instance.pnlOrderPurchasingParent;

            this._PanelInqueryContractSC = new PanelInqueryContractSC();
            this._PanelSettingOrderPurchasingSC = new PanelSettingOrderPurchasingSC();
        }
    }
}
