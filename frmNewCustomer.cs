using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract;
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
    public partial class frmDetailCustomer : Form
    {
        private static frmDetailCustomer _instance;
        public static frmDetailCustomer Instance
        {
            get
            {
                if (_instance == null) _instance = new frmDetailCustomer();
                return frmDetailCustomer._instance;
            }

            private set { frmDetailCustomer._instance = value; }
        }
        public frmDetailCustomer()
        {
            InitializeComponent();
        }

        protected CustomerGSES _CustomerGSESPreview;
        public CustomerGSES CustomerGSES => _CustomerGSESPreview;

        public virtual void SetCustomerGSES(CustomerGSES customerGSES) => this._CustomerGSESPreview = customerGSES;

        private void frmNewCustomer_Load(object sender, EventArgs e)
        {
            PanelCenterCusICSC.Instance.ShowAllInformationAfterOpen();
        }
    }
}
