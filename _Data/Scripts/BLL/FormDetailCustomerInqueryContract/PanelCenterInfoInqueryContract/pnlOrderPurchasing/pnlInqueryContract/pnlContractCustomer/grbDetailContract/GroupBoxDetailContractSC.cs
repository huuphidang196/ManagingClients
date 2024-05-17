using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlInqueryContract.pnlContractCustomer.grbDetailContract.flpDetailContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlOrderPurchasing.pnlInqueryContract.pnlContractCustomer.grbDetailContract
{
    public class GroupBoxDetailContractSC
    {
        protected GroupBox _grbDetailContract;

        protected FlowLayoutPanelDetailContractSC _FlowLayoutPanelDetailContractSC;
        public FlowLayoutPanelDetailContractSC FlowLayoutPanelDetailContractSC => _FlowLayoutPanelDetailContractSC;
        public GroupBoxDetailContractSC()
        {
            this._grbDetailContract = FrmDetailCustomer.Instance.grbDetailContract;

            this._FlowLayoutPanelDetailContractSC = new FlowLayoutPanelDetailContractSC();
        }
    }
}
