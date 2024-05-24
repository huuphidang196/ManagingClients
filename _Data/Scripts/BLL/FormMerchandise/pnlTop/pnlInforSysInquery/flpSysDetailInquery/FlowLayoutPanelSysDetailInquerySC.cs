using ManagingClients._Data.Scripts.DAO;
using ManagingClients._Data.Scripts.DAO.FormDetailCustomerIC;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormMerchandise.pnlTop.pnlInforSysInquery.flpSysDetailInquery
{
    public class FlowLayoutPanelSysDetailInquerySC
    {
        protected TextBox _txtNameInquery;
        protected TextBox _txtNumberInquery;
        protected TextBox _txtMinTimeDelevery;
        protected TextBox _txtMaxTimeDelivery;
        protected TextBox _txtSelectedExchangeRate;
        protected TextBox _txtRealisticExchangeRate;
        protected TextBox _txtEndUser;
        protected TextBox _txtPurposePurchasing;
        protected TextBox _txtTotalValueChar;

        protected Label _lblNameCustomerGSES;

        protected Label _lblTotalValueNoVAT;  //don't save
        protected Label _lblVATAllEquip;      //don't save
        protected Label _lblTotalValueHaveVAT;   //don't save

        protected DateTimePicker _dtpDateSending;
        protected DateTimePicker _dtpDateExpired;

        protected Button _btnSaveSysInquery;
        protected Button _btnInquerySysRemove;

        public FlowLayoutPanelSysDetailInquerySC()
        {
            this._txtNameInquery = frmMerchandise.Instance.txtNameInquery;
            this._txtNumberInquery = frmMerchandise.Instance.txtInqueryNumber;
            this._txtMinTimeDelevery = frmMerchandise.Instance.txtMinTimeDurationShip;
            this._txtMaxTimeDelivery = frmMerchandise.Instance.txtMaxTimeDurationShip;
            this._txtSelectedExchangeRate = frmMerchandise.Instance.txtSelectedExchangeRate;
            this._txtRealisticExchangeRate = frmMerchandise.Instance.txtRealisticExchange;
            this._txtEndUser = frmMerchandise.Instance.txtEndUser;
            this._txtPurposePurchasing = frmMerchandise.Instance.txtPurposePurchasing;
            this._txtTotalValueChar = frmMerchandise.Instance.txtTotalValueChar;

            this._lblNameCustomerGSES = frmMerchandise.Instance.lblNameCustomer;

            this._lblTotalValueNoVAT = frmMerchandise.Instance.lblTotalValueNoVAT;
            this._lblVATAllEquip = frmMerchandise.Instance.lblVATAllEquip;
            this._lblTotalValueHaveVAT = frmMerchandise.Instance.lbltotalValueHaveVAT;


            this._dtpDateSending = frmMerchandise.Instance.dtpDateSendInquery;
            this._dtpDateExpired = frmMerchandise.Instance.dtpDateExpiredInquery;

            this._btnSaveSysInquery = frmMerchandise.Instance.btnSaveSysInquery;
            this._btnInquerySysRemove = frmMerchandise.Instance.btnRemoveSysInquery;

           // this.ShowALLValueData();
        }


        #region Add_Events

        #endregion Add_Events

        #region Function_Internal
        public virtual void ShowALLValueData()
        {
            this._lblNameCustomerGSES.Text = FrmDetailCustomer.Instance.CustomerGSES.Name_Customer;

            InqueryQuotation inqueryQuotation = frmMerchandise.Instance.InqueryQuotation;
            this._txtNameInquery.Text = inqueryQuotation.Name_Inquiry_Quotation;
            this._txtNumberInquery.Text = inqueryQuotation.Number_Inquiry_Quotation;
            this._txtMinTimeDelevery.Text = inqueryQuotation.Min_Time_Delivery.ToString();
            this._txtMaxTimeDelivery.Text = inqueryQuotation.Max_Time_Delivery.ToString();
            this._txtSelectedExchangeRate.Text = inqueryQuotation.Selected_Exchange_Rate.ToString();
            this._txtRealisticExchangeRate.Text = inqueryQuotation.Real_Exchange_Rate.ToString();
            this._txtEndUser.Text = inqueryQuotation.Name_Of_EndUser;
            this._txtPurposePurchasing.Text = inqueryQuotation.Purpose_Purchasing;

            this._dtpDateSending.Value = inqueryQuotation.Date_Sending;
            this._dtpDateExpired.Value = inqueryQuotation.Date_Expired_Time_Inquiry;

            this.SetContentLabelValue();
        }

       
        protected virtual decimal GetTotalValueNoVAT()
        {
            return 0;
        }
        protected virtual decimal GetTotalVATEquip()
        {
            return 0;
        }
        protected virtual decimal GetTotalValueHaveVAT()
        {
            return 0;
        }

        protected virtual void SetContentLabelValue()
        {
            this._lblTotalValueNoVAT.Text = this.GetTotalValueNoVAT().ToString();
            this._lblVATAllEquip.Text = this.GetTotalVATEquip().ToString();
            this._lblTotalValueHaveVAT.Text = this.GetTotalValueHaveVAT().ToString();
        }
        #endregion

    }
}
