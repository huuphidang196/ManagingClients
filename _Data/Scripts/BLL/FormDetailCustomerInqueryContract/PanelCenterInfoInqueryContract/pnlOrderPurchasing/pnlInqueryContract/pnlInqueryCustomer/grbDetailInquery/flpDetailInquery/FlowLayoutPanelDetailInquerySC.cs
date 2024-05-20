using ManagingClients._Data.Scripts.DAO.FormDetailCustomerIC;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlInqueryContract.pnlInqueryCustomer.grbDetailInquery.flpDetailInquery
{
    public class FlowLayoutPanelDetailInquerySC
    {
        protected InqueryQuotation _InqueryQuotation;

        protected FlowLayoutPanel _flowDetailInquery;
        public FlowLayoutPanel FlowDetailInquery => _flowDetailInquery;

        protected TextBox _txtNameInquery;
        public TextBox TxtNameInquery => _txtNameInquery;

        protected TextBox _txtNumberInquery;
        public TextBox TxtNumberInquery => _txtNumberInquery;

        protected TextBox _txtCostDeliveryVN;
        public TextBox TxtCostDeliveryVN => _txtCostDeliveryVN;

        protected TextBox _txtCostDeliveryKH;
        public TextBox TxtCostDeliveryKH => _txtCostDeliveryKH;

        protected TextBox _txtMinTimeDurationShip;
        public TextBox TxtMinTimeDurationShip => _txtMinTimeDurationShip;

        protected TextBox _txtMaxTimeDurationShip;
        public TextBox TxtMaxTimeDurationShip => _txtMaxTimeDurationShip;

        protected TextBox _txtSelected_Exchange_Rate;
        public TextBox TxtSelectedExchangeRate => _txtSelected_Exchange_Rate;

        protected TextBox _txtPurposePurchasing;
        public TextBox TxtPurposePurchasing => _txtPurposePurchasing;

        protected TextBox _txtEndUser;
        public TextBox TxtEndUser => _txtEndUser;


        protected DateTimePicker _dtpDateSendInquery;
        public DateTimePicker DtpDateSendInquery => _dtpDateSendInquery;

        protected DateTimePicker _dtpDateExpiredInquery;
        public DateTimePicker DtpDateExpiredInquery => _dtpDateExpiredInquery;

        protected Label _lblShowFileInquery;

        protected Button _btnDeleteFileInquery;
        protected Button _btnDeleteInqueryQuotation;
        protected Button _btnSaveInquery;

        public FlowLayoutPanelDetailInquerySC()
        {
            // this._InqueryQuotation = new InqueryQuotation();

            this._txtNameInquery = FrmDetailCustomer.Instance.txtNameInquery;
            this._flowDetailInquery = FrmDetailCustomer.Instance.flpDetailInquery;

            this._txtNumberInquery = FrmDetailCustomer.Instance.txtInqueryNumber;

            this._txtCostDeliveryVN = FrmDetailCustomer.Instance.txtCostDeliveryVN;
            this._txtCostDeliveryKH = FrmDetailCustomer.Instance.txtCostDeliveryKH;
            this._txtMinTimeDurationShip = FrmDetailCustomer.Instance.txtMinTimeDurationShip;
            this._txtMaxTimeDurationShip = FrmDetailCustomer.Instance.txtMaxTimeDurationShip;
            this._txtSelected_Exchange_Rate = FrmDetailCustomer.Instance.txtSelectedExchangeRate;

            this._txtPurposePurchasing = FrmDetailCustomer.Instance.txtPurposePurchasing;
            this._txtEndUser = FrmDetailCustomer.Instance.txtEndUser;

            this._dtpDateSendInquery = FrmDetailCustomer.Instance.dtpDateSendInquery;
            this._dtpDateExpiredInquery = FrmDetailCustomer.Instance.dtpDateExpiredInquery;

            this._lblShowFileInquery = FrmDetailCustomer.Instance.lblShowFileInquery;
            this._lblShowFileInquery.Click += new EventHandler(ShowFileOrAddFilePDF);

            this._btnDeleteFileInquery = FrmDetailCustomer.Instance.btnDeleteFileInquery;
            this._btnDeleteFileInquery.Click += new EventHandler(AddEventClearFileInqueryButton);


            this._btnSaveInquery = FrmDetailCustomer.Instance.btnSaveInquery;
            this._btnSaveInquery.Click += new EventHandler(this.AddEventSaveInqueryButton);

            this._btnDeleteInqueryQuotation = FrmDetailCustomer.Instance.btnRemoveInquery;
            this._btnDeleteInqueryQuotation.Click += new EventHandler(AddEventClearAllDataInqueryButton);

            this.ClearContentOfControl();
            this.ActiveOrUnActiveAllControl(false);

            this._txtCostDeliveryVN.Leave += new EventHandler(this.AddEventCheckTextBoxNumberValidAfterPress);
            this._txtCostDeliveryKH.Leave += new EventHandler(this.AddEventCheckTextBoxNumberValidAfterPress);
            this._txtMinTimeDurationShip.Leave += new EventHandler(this.AddEventCheckTextBoxNumberValidAfterPress);
            this._txtMaxTimeDurationShip.Leave += new EventHandler(this.AddEventCheckTextBoxNumberValidAfterPress);
            this._txtSelected_Exchange_Rate.Leave += new EventHandler(this.AddEventCheckTextBoxNumberValidAfterPress);

        }

        public virtual void ChangeInqueryQuotationSelected(InqueryQuotation inqueryQuotation) => this._InqueryQuotation = inqueryQuotation;

        #region Add_Event
        protected virtual void ShowFileOrAddFilePDF(object sender, EventArgs e)
        {
            if (this._lblShowFileInquery.Enabled == false) return;

            if (this._InqueryQuotation.File_Data_Inquiry_Quotation == null)
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

                        this._InqueryQuotation.File_Data_Inquiry_Quotation = fileBytes;
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
            frmPDFFileReader.SetFileNameByte(this._InqueryQuotation.File_Data_Inquiry_Quotation);
            frmPDFFileReader.Show();
        }
        protected virtual void AddEventClearFileInqueryButton(object sender, EventArgs e)
        {
            this.ClearFileInquery();
        }
        protected virtual void AddEventClearAllDataInqueryButton(object sender, EventArgs e)
        {
            this.ClearContentOfControl();
        }

        protected virtual void AddEventSaveInqueryButton(object sender, EventArgs e)
        {
            if (this._InqueryQuotation.File_Data_Inquiry_Quotation == null)
            {
                MessageBox.Show("Vui lòng đính kèm tệp PDF File Báo Giá");
                return;
            }
            this.ProcessEventSaveInquery();
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
        #endregion

        #region Internal_Function
        protected virtual bool ProcessEventSaveInquery()
        {
            //Get CustomerOrder was generated
            CustomerOrder customerOrder_Of_Inquery = PanelCenterCusICSC.Instance.PanelOrderPurchasingCustomerSC.PanelSettingOrderPurchasingSC.GrbSettingOrderPurchasingSC.CustomerOrder_Creating;

            if (customerOrder_Of_Inquery.ID_Customer_Order == 0)
            {
                MessageBox.Show("Vui lòng Thiết lập Đơn Hàng trước ở Panel phía trên trước");
                return false;
            }
            this._InqueryQuotation = this.GetInqueryFromDataOnControl();
            this._InqueryQuotation.ID_Customer_Order = customerOrder_Of_Inquery.ID_Customer_Order;

            if (this._InqueryQuotation.Number_Inquiry_Quotation == "")
            {
                MessageBox.Show("Vui lòng nhập Số Báo giá");
                this._txtNumberInquery.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            this._txtNumberInquery.BackColor = System.Drawing.Color.White;

            if (this._InqueryQuotation.File_Data_Inquiry_Quotation == null)
            {
                MessageBox.Show("Vui lòng đính kèm tệp PDF File Báo Giá");
                return false;
            }

            bool saveSuccess = CustomerOrderDataProvider.Instance.InsertInqueryQuotation(this._InqueryQuotation);
            string str_Result = saveSuccess ? "Lưu Báo giá thành công! " : "Lưu thất bại";
            MessageBox.Show(str_Result);

            if (saveSuccess) this.ActiveOrUnActiveAllControl(false);

            //setting co
            //Save together
            PanelCenterCusICSC.Instance.PanelOrderPurchasingCustomerSC.PanelSettingOrderPurchasingSC.GrbSettingOrderPurchasingSC.ActiveOrUnActiveAllControl(false);
            return true;
        }
        protected virtual void ClearContentOfControl()
        {
            this._InqueryQuotation = new InqueryQuotation();

            this.SetContentControlByInquery(this._InqueryQuotation);
            this.ClearFileInquery();

            //Listview selected = 0

        }

        protected virtual void SetContentControlByInquery(InqueryQuotation inqueryQuotation)
        {
            this._InqueryQuotation = inqueryQuotation;

            this._txtNameInquery.Text = inqueryQuotation.Name_Inquiry_Quotation;
            this._txtNumberInquery.Text = inqueryQuotation.Number_Inquiry_Quotation;
            this._txtCostDeliveryVN.Text = inqueryQuotation.DeliveryCost_To_VietNam.ToString();
            this._txtCostDeliveryKH.Text = inqueryQuotation.DeliveryCost_To_Customer.ToString();
            this._txtMinTimeDurationShip.Text = inqueryQuotation.Min_Time_Delivery.ToString();
            this._txtMaxTimeDurationShip.Text = inqueryQuotation.Max_Time_Delivery.ToString();
            this._txtSelected_Exchange_Rate.Text = inqueryQuotation.Selected_Exchange_Rate.ToString();
            this._txtPurposePurchasing.Text = inqueryQuotation.Purpose_Purchasing;
            this._txtEndUser.Text = inqueryQuotation.Name_Of_EndUser;

            this._dtpDateSendInquery.Value = (inqueryQuotation.Date_Sending <= DateTime.MinValue) ? DateTime.Today : inqueryQuotation.Date_Sending;
            this._dtpDateExpiredInquery.Value = (inqueryQuotation.Expired_Time_Inquiry <= DateTime.MinValue) ? DateTime.Today : inqueryQuotation.Expired_Time_Inquiry;

            this._lblShowFileInquery.Text = (inqueryQuotation.File_Data_Inquiry_Quotation == null) ? "Tải file PDF" : "File Báo giá";

        }
        protected virtual void ClearFileInquery()
        {

            this._lblShowFileInquery.Text = "Tải file PDF";

            this._InqueryQuotation.File_Data_Inquiry_Quotation = null;
        }

        protected virtual void ActiveOrUnActiveAllControl(bool active)
        {
            this._txtNameInquery.ReadOnly = !active;
            this._txtNumberInquery.ReadOnly = !active;
            this._txtCostDeliveryVN.ReadOnly = !active;
            this._txtCostDeliveryKH.ReadOnly = !active;
            this._txtMinTimeDurationShip.ReadOnly = !active;
            this._txtMaxTimeDurationShip.ReadOnly = !active;
            this._txtSelected_Exchange_Rate.ReadOnly = !active;
            this._txtPurposePurchasing.ReadOnly = !active;
            this._txtEndUser.ReadOnly = !active;

            this._dtpDateSendInquery.Enabled = active;
            this._dtpDateExpiredInquery.Enabled = active;
            this._lblShowFileInquery.Enabled = active;

            this._btnDeleteFileInquery.Visible = active;
            this._btnSaveInquery.Visible = active;
            this._btnDeleteInqueryQuotation.Visible = active;
        }

        protected virtual InqueryQuotation GetInqueryFromDataOnControl()
        {
            InqueryQuotation inqueryQuotation = new InqueryQuotation();

            inqueryQuotation.ID_Inquery_Quotation = this._InqueryQuotation.ID_Inquery_Quotation;
            inqueryQuotation.Name_Inquiry_Quotation = this._txtNameInquery.Text;
            inqueryQuotation.Number_Inquiry_Quotation = this._txtNumberInquery.Text;
            inqueryQuotation.Date_Sending = this.DtpDateSendInquery.Value;
            inqueryQuotation.DeliveryCost_To_VietNam = decimal.Parse(this._txtCostDeliveryVN.Text);
            inqueryQuotation.DeliveryCost_To_Customer = decimal.Parse(this._txtCostDeliveryKH.Text);
            inqueryQuotation.Min_Time_Delivery = int.Parse(this._txtMinTimeDurationShip.Text);
            inqueryQuotation.Max_Time_Delivery = int.Parse(this._txtMaxTimeDurationShip.Text);
            inqueryQuotation.Expired_Time_Inquiry = this._dtpDateExpiredInquery.Value;
            inqueryQuotation.Selected_Exchange_Rate = decimal.Parse(this._txtSelected_Exchange_Rate.Text);

            inqueryQuotation.File_Data_Inquiry_Quotation = this._InqueryQuotation.File_Data_Inquiry_Quotation;
            inqueryQuotation.Purpose_Purchasing = this._txtPurposePurchasing.Text;
            inqueryQuotation.Name_Of_EndUser = this._txtEndUser.Text;

            //inqueryQuotation.ID_Customer_Order = 

            return inqueryQuotation;
        }
        #endregion

        #region Outside_Reference
        public virtual void CreatNewInqueryOfCustomer()
        {
            this.AllowEditInqueryQuotation();
            this.ClearContentOfControl();
        }
        public virtual void ListViewCustomerOrderChangeSelected(CustomerOrder customerOrder)
        {
            this.ActiveOrUnActiveAllControl(customerOrder.ID_Customer_Order == 0);

            this._InqueryQuotation = CustomerOrderDataProvider.Instance.GetInqueryQuotationrOrderOfCustomerByIDCustomerOrder(customerOrder.ID_Customer_Order);
            this.SetContentControlByInquery(this._InqueryQuotation);

        }

        public virtual void AllowEditInqueryQuotation()
        {
            this.ActiveOrUnActiveAllControl(true);
        }

        public virtual bool SaveInqueryCustomerOrderTogether()
        {
            return this.ProcessEventSaveInquery();
        }
        #endregion

    }
}
