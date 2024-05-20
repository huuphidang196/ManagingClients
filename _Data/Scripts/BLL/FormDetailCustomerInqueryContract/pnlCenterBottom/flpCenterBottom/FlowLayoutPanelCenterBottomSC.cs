using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.pnlBelowCusIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.pnlCenterBottom.flpCenterBottom
{
    public class FlowLayoutPanelCenterBottomSC
    {
        protected Button _btnLoadListCustomerOrder;

        public FlowLayoutPanelCenterBottomSC()
        {
            this._btnLoadListCustomerOrder = FrmDetailCustomer.Instance.btnLoadListCustomerOrder;
            this._btnLoadListCustomerOrder.Click += new EventHandler(this.AddEventLoadAllListCustomerOrder);
        }

        protected virtual void AddEventLoadAllListCustomerOrder(object sender, EventArgs e)
        {
            PanelBelowCusICSC.Instance.TabCtrlInqueryContractSC.TabPageInqueryCustomerSC.ShowAndSetSelectedItem();

        }
    }
}
