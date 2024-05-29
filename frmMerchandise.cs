using ManagingClients._Data.Scripts.BLL.FormMerchandise.pnlTop;
using ManagingClients._Data.Scripts.DTO.Account;
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
    public partial class frmMerchandise : Form
    {
        private static frmMerchandise _instance;
        public static frmMerchandise Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new frmMerchandise();
                }
                return _instance;
            }

            private set { frmMerchandise._instance = value; }
        }

        protected InqueryQuotation _InqueryQuotation;
        public InqueryQuotation InqueryQuotation => _InqueryQuotation;

        public virtual void SetInqueryQuotation(InqueryQuotation inqueryQuotation) => this._InqueryQuotation = inqueryQuotation;

        public frmMerchandise()
        {
            InitializeComponent();
        }

        private void frmMerchandise_Load(object sender, EventArgs e)
        {
            //Panel Detail Inquery Sysstem
            PanelTopMerchandiseSC.Instance.ShowAllValueOnScene();
        }

        private void frmMerchandise_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
            PanelTopMerchandiseSC.Instance = null;
        }
    }
}
