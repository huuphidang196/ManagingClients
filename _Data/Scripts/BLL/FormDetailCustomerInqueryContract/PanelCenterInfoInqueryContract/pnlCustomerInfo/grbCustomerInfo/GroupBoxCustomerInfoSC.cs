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
            this._txtNameCustomer = FrmDetailCustomer.Instance.txtNameCustomer;
            this._txtAddressCustomer = FrmDetailCustomer.Instance.txtAddressCustomer;
            this._txtEmailCustomer = FrmDetailCustomer.Instance.txtEmailCustomer;
            this._txtPhoneCustomer = FrmDetailCustomer.Instance.txtPhoneCustomer;
            this._txtTaxCustomer = FrmDetailCustomer.Instance.txtTaxCustomer;

            this.SetValueBegin();
        }

        protected virtual void SetValueBegin()
        {
            CustomerGSES customerGSES = FrmDetailCustomer.Instance.CustomerGSES;

            this._txtNameCustomer.Text = customerGSES.Name_Customer;
            this._txtAddressCustomer.Text = customerGSES.Address_Company;
            this._txtEmailCustomer.Text = customerGSES.Address_Email;
            this._txtPhoneCustomer.Text = customerGSES.Phone_Number;
            this._txtTaxCustomer.Text = customerGSES.Tax_Number;
        }
    }
}
