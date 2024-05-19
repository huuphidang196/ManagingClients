using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder.pnlOptions.pnlHeaderOption
{
    public class PanelHeaderOptionSC
    {
        protected MenuStrip _mnsOptionHeader;
        public MenuStrip MenuStripOptionsHeader => _mnsOptionHeader;

        public PanelHeaderOptionSC()
        {
            this._mnsOptionHeader = FrmMain_Control.Instance.mnsOptionHeader;

            this._mnsOptionHeader.Items[0].Click += new EventHandler(this.AddEventsAddNewCustomerInqueryContract);
        }

        protected virtual void AddEventsAddNewCustomerInqueryContract(object sender, EventArgs e)
        {
            CustomerGSES customerGSES = new CustomerGSES();

            FrmDetailCustomer.Instance.SetCustomerGSES(customerGSES);
            FrmDetailCustomer.Instance.Show();
        }

    }
}
