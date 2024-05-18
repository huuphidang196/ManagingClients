using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlInqueryContract.pnlInqueryCustomer;
using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlOrderPurchasing.pnlInqueryContract.pnlContractCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlInqueryContract
{
    public class PanelInqueryContractSC
    {
        protected Panel _pnlInqueryContract;

        protected PanelInqueryCustomerSC _PanelInqueryCustomerSC;
        public PanelInqueryCustomerSC PanelInqueryCustomerSC => _PanelInqueryCustomerSC;

        protected PanelContractCustomerSC _PanelContractCustomerSC;
        public PanelContractCustomerSC PanelContractCustomerSC => _PanelContractCustomerSC;
        public PanelInqueryContractSC()
        {
            this._pnlInqueryContract = FrmDetailCustomer.Instance.pnlInqueryContract;

            this._PanelContractCustomerSC = new PanelContractCustomerSC();
            this._PanelInqueryCustomerSC = new PanelInqueryCustomerSC();
        }


    }
}
