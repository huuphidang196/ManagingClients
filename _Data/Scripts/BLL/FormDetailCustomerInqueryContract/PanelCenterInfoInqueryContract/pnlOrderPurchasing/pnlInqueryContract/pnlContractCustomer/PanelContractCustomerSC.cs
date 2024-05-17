using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlOrderPurchasing.pnlInqueryContract.pnlContractCustomer.grbDetailContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlOrderPurchasing.pnlInqueryContract.pnlContractCustomer
{
    public class PanelContractCustomerSC
    {
        protected Panel _pnlContractCustomerSC;
        protected GroupBoxDetailContractSC _GroupBoxDetailContractSC;
        public GroupBoxDetailContractSC GroupBoxDetailContractSC => _GroupBoxDetailContractSC;
        public PanelContractCustomerSC()
        {
            this._pnlContractCustomerSC = FrmDetailCustomer.Instance.pnlContractOrderCus;

            this._GroupBoxDetailContractSC = new GroupBoxDetailContractSC();

        }
    }
}
