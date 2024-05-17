using ManagingClients._Data.Scripts.DAO.Scene_Manage_Customer.pnlMainControl.pnlDisplayOverall.pnlDetailProfile;
using ManagingClients._Data.Scripts.DTO.Account;
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
    public partial class frmUserLoginForm : Form
    {
        public frmUserLoginForm()
        {
            InitializeComponent();
        }

        private void frmUserLoginForm_Load(object sender, EventArgs e)
        {
            this.SetSomeDataOnLoaded();
        }

        protected virtual void SetSomeDataOnLoaded()
        {
            this.txtNameLoginAccount.Focus();
        }

        private void btnLoginAccount_Click(object sender, EventArgs e)
        {
            ProfileAccount profileAccount = this.GetProfileAccount();

            if (profileAccount == null)
            {
                MessageBox.Show("Sai thông tin đăng nhập");

                return;
            }

            this.Close();

            FrmMain_Control.Instance.SetProfileAccount(profileAccount);
        }

        private void frmUserLoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProfileAccount profileAccount = this.GetProfileAccount();

            if (profileAccount != null) return;

            Application.Exit();

            // Dừng chương trình hoàn toàn
            Environment.Exit(0);
        }

      
        protected virtual ProfileAccount GetProfileAccount()
        {
            ProfileAccount profileAccount = DetailProfileProvider.Instance.GetProfileAccount(this.txtNameLoginAccount.Text);


            return profileAccount;
        }
    }
}
