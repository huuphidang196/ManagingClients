using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlBelow.TabCtrlnqueryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.pnlBelowCusIC
{
    public class PanelBelowCusICSC
    {
        protected TabCtrlInqueryContractSC _TabCtrlInqueryContractSC;
        public TabCtrlInqueryContractSC TabCtrlInqueryContractSC => _TabCtrlInqueryContractSC;

        public PanelBelowCusICSC()
        {
            this._TabCtrlInqueryContractSC = new TabCtrlInqueryContractSC();
        }
    }
}
