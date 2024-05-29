using ManagingClients._Data.Scripts.DAO;
using ManagingClients._Data.Scripts.DAO.FormDetailCustomerIC;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormMerchandise.pnlTop.pnlInforSysInquery.flpSysDetailInquery
{
    public class FlowLayoutPanelSysDetailInquerySC
    {
        protected InqueryQuotation _InqueryQuotation;

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
        protected Label _lblShowFileInquery;

        protected DateTimePicker _dtpDateSending;
        protected DateTimePicker _dtpDateExpired;

        protected Button _btnDeleteFileInquery;
        protected Button _btnSaveSysInquery;
        protected Button _btnInquerySysRemove;

        public FlowLayoutPanelSysDetailInquerySC()
        {
            PanelTopMerchandiseSC.EventShowAllDataOnLoad += this.ShowALLValueData;

            this._InqueryQuotation = frmMerchandise.Instance.InqueryQuotation;

            this._txtNameInquery = frmMerchandise.Instance.txtNameInquery;
            this._txtNumberInquery = frmMerchandise.Instance.txtInqueryNumber;

            this._txtMinTimeDelevery = frmMerchandise.Instance.txtMinTimeDurationShip;
            this._txtMinTimeDelevery.Leave += new EventHandler(AddEventCheckTextBoxNumberValidAfterPress);

            this._txtMaxTimeDelivery = frmMerchandise.Instance.txtMaxTimeDurationShip;
            this._txtMaxTimeDelivery.Leave += new EventHandler(AddEventCheckTextBoxNumberValidAfterPress);

            this._txtSelectedExchangeRate = frmMerchandise.Instance.txtSelectedExchangeRate;
            this._txtSelectedExchangeRate.Leave += new EventHandler(AddEventCheckTextBoxNumberValidAfterPress);

            this._txtRealisticExchangeRate = frmMerchandise.Instance.txtRealisticExchange;
            this._txtRealisticExchangeRate.Leave += new EventHandler(AddEventCheckTextBoxNumberValidAfterPress);

            this._txtEndUser = frmMerchandise.Instance.txtEndUser;
            this._txtPurposePurchasing = frmMerchandise.Instance.txtPurposePurchasing;
            this._txtTotalValueChar = frmMerchandise.Instance.txtTotalValueChar;
            this._txtTotalValueChar.Leave += new EventHandler(AddEventCheckTextBoxNumberValidAfterPress);

            this._lblNameCustomerGSES = frmMerchandise.Instance.lblNameCustomer;

            this._lblTotalValueNoVAT = frmMerchandise.Instance.lblTotalValueNoVAT;
            this._lblVATAllEquip = frmMerchandise.Instance.lblVATAllEquip;
            this._lblTotalValueHaveVAT = frmMerchandise.Instance.lbltotalValueHaveVAT;

            this._lblShowFileInquery = frmMerchandise.Instance.lblShowFileInquery;
            this._lblShowFileInquery.Click += new EventHandler(ShowFileOrAddFilePDF);

            this._dtpDateSending = frmMerchandise.Instance.dtpDateSendInquery;
            this._dtpDateExpired = frmMerchandise.Instance.dtpDateExpiredInquery;

            this._btnDeleteFileInquery = frmMerchandise.Instance.btnDeleteFileInquery;
            this._btnDeleteFileInquery.Click += new EventHandler(AddEventClearFileInqueryButton);

            this._btnSaveSysInquery = frmMerchandise.Instance.btnSaveSysInquery;
            this._btnSaveSysInquery.Click += new EventHandler(EventSaveInquerySystem);

            this._btnInquerySysRemove = frmMerchandise.Instance.btnRemoveSysInquery;
            this._btnInquerySysRemove.Click += new EventHandler(AddEventClearAllDataInqueryButton);


            // this.ShowALLValueData();
        }


        #region Add_Events
        protected virtual void AddEventClearFileInqueryButton(object sender, EventArgs e)
        {
            this.ClearFileInquery();
        }
        protected virtual void ShowFileOrAddFilePDF(object sender, EventArgs e)
        {
            if (this._lblShowFileInquery.Enabled == false) return;

            if (this._InqueryQuotation.File_Data_MR_Inquiry_Quotation == null)
            {
                // Hiển thị hộp thoại chọn file
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*",
                    Title = "Select a PDF file"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn file được chọn
                    string filePath = openFileDialog.FileName;
                    // Lấy tên file (không bao gồm đường dẫn)
                    string fileName = openFileDialog.SafeFileName;

                    try
                    {
                        // Chuyển đổi file PDF thành mảng byte
                        byte[] fileBytes = File.ReadAllBytes(filePath);

                        this._InqueryQuotation.File_Data_MR_Inquiry_Quotation = fileBytes;
                        this._lblShowFileInquery.Text = fileName;               
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error reading file: {ex.Message}");
                    }
                }

                return;
            }

            //Selected 1 item
            frmPDFFileReader frmPDFFileReader = new frmPDFFileReader();
            frmPDFFileReader.SetFileNameByte(this._InqueryQuotation.File_Data_MR_Inquiry_Quotation);
            frmPDFFileReader.Show();
        }
        protected virtual void AddEventCheckTextBoxNumberValidAfterPress(object sender, EventArgs e)
        {
            TextBox textBoxChecked = sender as TextBox;

            bool isNumber = textBoxChecked.Text.All(c => (char.IsDigit(c) || c == '.'));

            if (!isNumber)
            {
                MessageBox.Show("Vui lòng nhập hợp lệ");
                textBoxChecked.BackColor = System.Drawing.Color.Yellow;
                return;
            }
            textBoxChecked.BackColor = System.Drawing.Color.White;

        }

        protected virtual void EventSaveInquerySystem(object sender, EventArgs e)
        {
            if (this._InqueryQuotation.File_Data_MR_Inquiry_Quotation == null)
            {
                MessageBox.Show("Vui lòng đính kèm tệp PDF File MR Gốc");
                return;
            }

            this.ProcessEventSaveInquery();
        }
        protected virtual void AddEventClearAllDataInqueryButton(object sender, EventArgs e)
        {
            this.ClearContentOfControl();
        }


        #endregion Add_Events

        #region Function_Internal
        protected virtual void ClearContentOfControl()
        {
            this._InqueryQuotation = new InqueryQuotation();
            this._InqueryQuotation.ID_Customer_Order = frmMerchandise.Instance.InqueryQuotation.ID_Customer_Order;

            this.SetContentControlByInquery(this._InqueryQuotation);
            this.ClearFileInquery();

            //Listview selected = 0

        }
        protected virtual void ClearFileInquery()
        {
            this._lblShowFileInquery.Text = "Tải file PDF";

            this._InqueryQuotation.File_Data_MR_Inquiry_Quotation = null;
        }
        public virtual void ShowALLValueData()
        {
            this._lblNameCustomerGSES.Text = FrmDetailCustomer.Instance.CustomerGSES.Name_Customer;

            InqueryQuotation inqueryQuotation = frmMerchandise.Instance.InqueryQuotation;

            this.SetContentControlByInquery(inqueryQuotation);
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

        protected virtual bool ProcessEventSaveInquery()
        {
            this._InqueryQuotation = this.GetInqueryQuotationByAssembleAllControl();

            if (this._InqueryQuotation.Number_Inquiry_Quotation == "")
            {
                MessageBox.Show("Vui lòng nhập Số Báo giá");
                this._txtNumberInquery.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            this._txtNumberInquery.BackColor = System.Drawing.Color.White;

            if (this._InqueryQuotation.File_Data_MR_Inquiry_Quotation == null)
            {
                MessageBox.Show("Vui lòng đính kèm tệp PDF File Báo Giá MR");
                return false;
            }

            if (this._InqueryQuotation.File_Data_Inquiry_Quotation == null)
            {
                this._InqueryQuotation.File_Data_Inquiry_Quotation = this._InqueryQuotation.File_Data_MR_Inquiry_Quotation;
            }

            bool saveSuccess = CustomerOrderDataProvider.Instance.InsertInqueryQuotation(this._InqueryQuotation);
            string str_Result = saveSuccess ? "Lưu Báo giá thành công! " : "Lưu thất bại";
            MessageBox.Show(str_Result);

            if (saveSuccess) this.ActiveOrUnActiveAllControl(false);

            //setting co
            //Save together

            return true;
        }

        protected virtual void ActiveOrUnActiveAllControl(bool active)
        {
            this._txtNameInquery.Enabled = active;
            this._txtNumberInquery.Enabled = active;
            this._txtMinTimeDelevery.Enabled = active;
            this._txtMaxTimeDelivery.Enabled = active;
            this._txtSelectedExchangeRate.Enabled = active;
            this._txtRealisticExchangeRate.Enabled = active;
            this._txtEndUser.Enabled = active;
            this._txtPurposePurchasing.Enabled = active;

            this._dtpDateSending.Enabled = active;
            this._dtpDateExpired.Enabled = active;
        }
        protected virtual InqueryQuotation GetInqueryQuotationByAssembleAllControl()
        {
            InqueryQuotation inqueryQuotation = new InqueryQuotation();

            inqueryQuotation.ID_Customer_Order = this._InqueryQuotation.ID_Customer_Order;

            inqueryQuotation.ID_Inquery_Quotation = this._InqueryQuotation.ID_Inquery_Quotation;
            inqueryQuotation.Name_Inquiry_Quotation = this._txtNameInquery.Text;
            inqueryQuotation.Number_Inquiry_Quotation = this._txtNumberInquery.Text;
            inqueryQuotation.Date_Sending = this._dtpDateSending.Value;
            inqueryQuotation.Date_Expired_Time_Inquiry = this._dtpDateExpired.Value;

            inqueryQuotation.Min_Time_Delivery = int.Parse(this._txtMinTimeDelevery.Text);
            inqueryQuotation.Max_Time_Delivery = int.Parse(this._txtMaxTimeDelivery.Text);

            inqueryQuotation.Selected_Exchange_Rate = decimal.Parse(this._txtSelectedExchangeRate.Text);
            inqueryQuotation.Real_Exchange_Rate = decimal.Parse(this._txtRealisticExchangeRate.Text);

            inqueryQuotation.File_Data_MR_Inquiry_Quotation = this._InqueryQuotation.File_Data_MR_Inquiry_Quotation;
            inqueryQuotation.Purpose_Purchasing = this._txtPurposePurchasing.Text;
            inqueryQuotation.Name_Of_EndUser = this._txtEndUser.Text;

            return inqueryQuotation;

        }
        protected virtual void SetContentControlByInquery(InqueryQuotation inqueryQuotation)
        {
            this._InqueryQuotation = inqueryQuotation;

            this._txtNameInquery.Text = inqueryQuotation.Name_Inquiry_Quotation;
            this._txtNumberInquery.Text = inqueryQuotation.Number_Inquiry_Quotation;
            this._txtMinTimeDelevery.Text = inqueryQuotation.Min_Time_Delivery.ToString();
            this._txtMaxTimeDelivery.Text = inqueryQuotation.Max_Time_Delivery.ToString();
            this._txtSelectedExchangeRate.Text = inqueryQuotation.Selected_Exchange_Rate.ToString();
            this._txtRealisticExchangeRate.Text = inqueryQuotation.Real_Exchange_Rate.ToString();
            this._txtEndUser.Text = inqueryQuotation.Name_Of_EndUser;
            this._txtPurposePurchasing.Text = inqueryQuotation.Purpose_Purchasing;

            this._dtpDateSending.Value = (inqueryQuotation.Date_Sending <= DateTime.MinValue) ? DateTime.Today : inqueryQuotation.Date_Sending;
            this._dtpDateExpired.Value = (inqueryQuotation.Date_Expired_Time_Inquiry <= DateTime.MinValue) ? DateTime.Today : inqueryQuotation.Date_Expired_Time_Inquiry;

            this.SetContentLabelValue();

        }
        #endregion

    }
}
