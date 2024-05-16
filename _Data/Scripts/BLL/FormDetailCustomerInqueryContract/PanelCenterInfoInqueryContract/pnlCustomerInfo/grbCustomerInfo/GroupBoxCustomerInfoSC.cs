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

        public GroupBoxCustomerInfoSC()
        {
            this._txtNameCustomer = frmDetailCustomer.Instance.txtNameCustomer;
            this._txtAddressCustomer = frmDetailCustomer.Instance.txtAddressCustomer;
            this._txtEmailCustomer = frmDetailCustomer.Instance.txtEmailCustomer;
            this._txtPhoneCustomer = frmDetailCustomer.Instance.txtPhoneCustomer;
            this._txtTaxCustomer = frmDetailCustomer.Instance.txtTaxCustomer;

            this.SetValueBegin();
        }

        protected virtual void SetValueBegin()
        {
            CustomerGSES customerGSES = frmDetailCustomer.Instance.CustomerGSES;

            this._txtNameCustomer.Text = customerGSES.Name_Customer;
            this._txtAddressCustomer.Text = customerGSES.Address_Company;
            this._txtEmailCustomer.Text = customerGSES.Address_Email;
            this._txtPhoneCustomer.Text = customerGSES.Phone_Number;
            this._txtTaxCustomer.Text = customerGSES.Tax_Number;
        }
    }
}
