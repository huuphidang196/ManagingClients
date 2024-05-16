using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlBelow.tabCtrlInqueryContract
{
    public class TabPageInqueryCustomerSC
    {
        protected ListView _lsvInqueryCus;

        public TabPageInqueryCustomerSC()
        {
            this._lsvInqueryCus = frmDetailCustomer.Instance.lsvInqueryCus;
        }
    }
}
