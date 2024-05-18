using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract;
using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract;
using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.pnlBelowCusIC;
using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.pnlTopCusIC;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients
{
    public partial class FrmDetailCustomer : Form
    {
        private static FrmDetailCustomer _instance;
        public static FrmDetailCustomer Instance
        {
            get
            {
                if (_instance == null) _instance = new FrmDetailCustomer();
                return FrmDetailCustomer._instance;
            }

            private set { FrmDetailCustomer._instance = value; }
        }
        private FrmDetailCustomer()
        {
            InitializeComponent();

        }


        protected CustomerGSES _CustomerGSESPreview;
        public CustomerGSES CustomerGSES => _CustomerGSESPreview;

        public virtual void SetCustomerGSES(CustomerGSES customerGSES) => this._CustomerGSESPreview = customerGSES;

        private void frmNewCustomer_Load(object sender, EventArgs e)
        {
            PanelTopCusICSC.Instance.ShowAllDataWhenBegin();
            PanelCenterCusICSC.Instance.ShowAllInformationAfterOpen();
            PanelBelowCusICSC.Instance.ShowAllInformationAfterOpen();
        }
    }
}
