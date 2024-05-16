using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlBelow.tabCtrlInqueryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlBelow.TabCtrlnqueryContract
{
    public class TabCtrlInqueryContractSC
    {
        protected TabControl _tabCtrlInqueryContract;

        protected TabPageInqueryCustomerSC _TabPageInqueryCustomerSC;
        public TabPageInqueryCustomerSC TabPageInqueryCustomerSC => _TabPageInqueryCustomerSC;
        public TabCtrlInqueryContractSC()
        {
            this._tabCtrlInqueryContract = frmDetailCustomer.Instance.tabCtrlInqueryContract;
            this._TabPageInqueryCustomerSC = new TabPageInqueryCustomerSC();

        }
    }
}
