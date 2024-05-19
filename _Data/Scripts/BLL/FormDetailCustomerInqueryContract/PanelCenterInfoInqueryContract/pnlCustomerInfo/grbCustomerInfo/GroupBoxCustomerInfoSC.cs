using ManagingClients._Data.Scripts.DAO.FormDetailCustomerIC;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.PanelCenterInfoInqueryContract.pnlCustomerInfo.grbCustomerInfo
{
    public class GroupBoxCustomerInfoSC
    {
        protected TextBox _txtNameCustomer;
        protected TextBox _txtAddressCustomer;
        protected TextBox _txtEmailCustomer;
        protected TextBox _txtPhoneCustomer;
        protected TextBox _txtTaxCustomer;

        protected Button _btnSaveDataCustomer;

        public GroupBoxCustomerInfoSC()
        {
            this._txtNameCustomer = FrmDetailCustomer.Instance.txtNameCustomer;
            this._txtAddressCustomer = FrmDetailCustomer.Instance.txtAddressCustomer;
            this._txtEmailCustomer = FrmDetailCustomer.Instance.txtEmailCustomer;
            this._txtPhoneCustomer = FrmDetailCustomer.Instance.txtPhoneCustomer;
            this._txtTaxCustomer = FrmDetailCustomer.Instance.txtTaxCustomer;

            this._btnSaveDataCustomer = FrmDetailCustomer.Instance.btnSaveDataCustomer;
            this._btnSaveDataCustomer.Click += new EventHandler(this.AddEventSaveCustomerInfomation);

            this.SetValueBegin();
        }

        #region Add_Events
        protected virtual void AddEventSaveCustomerInfomation(object sender, EventArgs e)
        {
            CustomerGSES customerGSES = this.GetCustomerGSES();

            //Insert or Update
            bool saveSuccess = CustomerOrderDataProvider.Instance.InsertCustomerGSES(customerGSES);

            string strContent = (saveSuccess) ? "Lưu Thông tin khách hàng thành công" : "Lưu thất bại. Vui lòng thử lại";

            MessageBox.Show(strContent);

            //Off buttonSave
            this.SetActiveAllControlOfCustomerInformation(false);
        }
        #endregion Add_Events
        protected virtual void SetValueBegin()
        {
            CustomerGSES customerGSES = FrmDetailCustomer.Instance.CustomerGSES;

            this._txtNameCustomer.Text = customerGSES.Name_Customer;
            this._txtAddressCustomer.Text = customerGSES.Address_Company;
            this._txtEmailCustomer.Text = customerGSES.Address_Email;
            this._txtPhoneCustomer.Text = customerGSES.Phone_Number;
            this._txtTaxCustomer.Text = customerGSES.Tax_Number;

            this.SetActiveAllControlOfCustomerInformation(false);
        }

        protected virtual CustomerGSES GetCustomerGSES()
        {
            CustomerGSES customerGSES = new CustomerGSES();

            customerGSES.ID_Customer = FrmDetailCustomer.Instance.CustomerGSES.ID_Customer;
            customerGSES.Name_Customer = this._txtNameCustomer.Text;
            customerGSES.Address_Company = this._txtAddressCustomer.Text;
            customerGSES.Address_Email = this._txtEmailCustomer.Text;
            customerGSES.Phone_Number = this._txtPhoneCustomer.Text;
            customerGSES.Tax_Number = this._txtTaxCustomer.Text;

            return customerGSES;
        }

        protected virtual void SetActiveAllControlOfCustomerInformation(bool active)
        {
            this._txtNameCustomer.Enabled = active;
            this._txtAddressCustomer.Enabled = active;
            this._txtEmailCustomer.Enabled = active;
            this._txtPhoneCustomer.Enabled = active;
            this._txtTaxCustomer.Enabled = active;

            this._btnSaveDataCustomer.Visible = active;
        }

        public virtual void AllowEditAllControlOfCustomerOrder()
        {
            this.SetActiveAllControlOfCustomerInformation(true);
        }
    }
}
