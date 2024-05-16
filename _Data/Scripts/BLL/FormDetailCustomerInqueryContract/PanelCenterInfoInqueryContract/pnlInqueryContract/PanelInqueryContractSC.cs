using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlInqueryContract.pnlInqueryCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlInqueryContract
{
    public class PanelInqueryContractSC
    {
        protected PanelInqueryCustomerSC _PanelInqueryCustomerSC;
        public PanelInqueryCustomerSC PanelInqueryCustomerSC => _PanelInqueryCustomerSC;

        public PanelInqueryContractSC()
        {
            this._PanelInqueryCustomerSC = new PanelInqueryCustomerSC();
        }
    }
}
