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
        protected ListView _lsvOrdersCustomer;

        public TabPageInqueryCustomerSC()
        {
            this._lsvOrdersCustomer = FrmDetailCustomer.Instance.lsvOrdersCustomer;
            this._lsvOrdersCustomer.MultiSelect = false;
        }

        public virtual void AddNewInquery()
        {
            if (this._lsvOrdersCustomer.SelectedItems.Count == 0) return;

            this._lsvOrdersCustomer.SelectedItems[0].Selected = false;
        }
    }
}
