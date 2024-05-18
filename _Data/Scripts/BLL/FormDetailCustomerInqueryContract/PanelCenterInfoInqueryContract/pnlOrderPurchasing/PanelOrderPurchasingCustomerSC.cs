using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlBelow.tabCtrlInqueryContract;
using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlInqueryContract;
using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlOrderPurchasing.pnlSettingOrderPurchasing;
using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.pnlBelowCusIC;
using ManagingClients._Data.Scripts.DTO.Customer;
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

        protected CustomerOrder _CustomerOrder;
        public CustomerOrder CustomerOrder => _CustomerOrder;

        protected PanelInqueryContractSC _PanelInqueryContractSC;
        public PanelInqueryContractSC PanelInqueryContractSC => _PanelInqueryContractSC;

        protected PanelSettingOrderPurchasingSC _PanelSettingOrderPurchasingSC;
        public PanelSettingOrderPurchasingSC PanelSettingOrderPurchasingSC => _PanelSettingOrderPurchasingSC;
     
        public PanelOrderPurchasingCustomerSC()
        {

            this._CustomerOrder = new CustomerOrder();

            this._pnlOrderPurchasingCustomerParent = FrmDetailCustomer.Instance.pnlOrderPurchasingParent;

            this._PanelInqueryContractSC = new PanelInqueryContractSC();
            this._PanelSettingOrderPurchasingSC = new PanelSettingOrderPurchasingSC();

            //Signed event ListViewCustomerOrderChangeSelected
            TabPageInqueryCustomerSC.EventShowDataICOfOrder += this.ListViewCustomerOrderChangeSelected;
        }

        #region Add_Events
        protected virtual void ListViewCustomerOrderChangeSelected(CustomerOrder customerOrder)
        {
            //setting
            this._PanelSettingOrderPurchasingSC.GrbSettingOrderPurchasingSC.ListViewCustomerOrderChangeSelected(customerOrder);
            //Inquery
            this._PanelInqueryContractSC.PanelInqueryCustomerSC.ListViewCustomerOrderChangeSelected(customerOrder);

            //Contract 
            this._PanelInqueryContractSC.PanelContractCustomerSC.GroupBoxDetailContractSC.FlowLayoutPanelDetailContractSC.ListViewCustomerOrderChangeSelected(customerOrder);
           

        }
        #endregion
        public virtual void ButtonAddOrderCustomer()
        {
            //new Setting Order
            this._PanelSettingOrderPurchasingSC.GrbSettingOrderPurchasingSC.CreatNewInqueryAndContractOfCustomerAndSetSetting();
            //New Contract
            this._PanelInqueryContractSC.PanelContractCustomerSC.GroupBoxDetailContractSC.FlowLayoutPanelDetailContractSC.CreatNewContractOfCustomer();
            
            //New Inquery
            this._PanelInqueryContractSC.PanelInqueryCustomerSC.FlowLayoutPanelDetailInquerySC.CreatNewInqueryOfCustomer();

        }

        public virtual void AllowEditCustomerOrderAndContractInquery()
        {
            //setting co
            this.PanelSettingOrderPurchasingSC.GrbSettingOrderPurchasingSC.AllowEditCustomerOrder();

            //Inquery
            this._PanelInqueryContractSC.PanelInqueryCustomerSC.FlowLayoutPanelDetailInquerySC.AllowEditCustomerOrder();

            //Contract
            this._PanelInqueryContractSC.PanelContractCustomerSC.GroupBoxDetailContractSC.FlowLayoutPanelDetailContractSC.AllowEditCustomerOrder();
        }
    }
}
