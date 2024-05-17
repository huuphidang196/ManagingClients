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
            this._pnlOrderPurchasingCustomerParent = FrmDetailCustomer.Instance.pnlOrderPurchasingParent;

            this._PanelInqueryContractSC = new PanelInqueryContractSC();
            this._PanelSettingOrderPurchasingSC = new PanelSettingOrderPurchasingSC();
        }

        public virtual void ButtonAddOrderCustomer()
        {
            //new Setting Order
            this._PanelSettingOrderPurchasingSC.GrbSettingOrderPurchasingSC.CreatNewInqueryAndContractOfCustomer();
            //New Contract
            this._PanelInqueryContractSC.PanelContractCustomerSC.GroupBoxDetailContractSC.FlowLayoutPanelDetailContractSC.CreatNewContractOfCustomer();
            
            //New Inquery
            this._PanelInqueryContractSC.PanelInqueryCustomerSC.FlowLayoutPanelDetailInquerySC.CreatNewInqueryOfCustomer();

        }
    }
}
