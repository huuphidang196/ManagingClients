using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlInqueryContract.pnlInqueryCustomer.grbDetailInquery.flpDetailInquery;
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
            this._pnlInqueryCustomer = frmDetailCustomer.Instance.pnlInqueryCustomer;
            this._FlowLayoutPanelDetailInquerySC = new FlowLayoutPanelDetailInquerySC();

        }
    }
}
