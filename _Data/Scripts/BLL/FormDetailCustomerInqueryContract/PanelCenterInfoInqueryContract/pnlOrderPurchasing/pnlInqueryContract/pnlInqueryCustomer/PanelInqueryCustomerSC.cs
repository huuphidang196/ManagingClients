using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlBelow.tabCtrlInqueryContract;
using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlInqueryContract.pnlContractCustomer.grbDetailContract.flpDetailContract;
using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlInqueryContract.pnlInqueryCustomer.grbDetailInquery.flpDetailInquery;
using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.pnlBelowCusIC;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlInqueryContract.pnlInqueryCustomer
{
    public class PanelInqueryCustomerSC
    {
        protected Panel _pnlInqueryCustomer;
        public Panel PanelInqueryCustomer => _pnlInqueryCustomer;

        protected FlowLayoutPanelDetailInquerySC _FlowLayoutPanelDetailInquerySC;
        public FlowLayoutPanelDetailInquerySC FlowLayoutPanelDetailInquerySC => _FlowLayoutPanelDetailInquerySC;

        public PanelInqueryCustomerSC()
        {
            this._pnlInqueryCustomer = FrmDetailCustomer.Instance.pnlInqueryCustomer;
            this._FlowLayoutPanelDetailInquerySC = new FlowLayoutPanelDetailInquerySC();   
          
        }

        public virtual void ListViewCustomerOrderChangeSelected(CustomerOrder customerOrder)
        {
            //Find Inquery by Id customerOrder
            this._FlowLayoutPanelDetailInquerySC.ListViewCustomerOrderChangeSelected(customerOrder);

        }

    }
}
