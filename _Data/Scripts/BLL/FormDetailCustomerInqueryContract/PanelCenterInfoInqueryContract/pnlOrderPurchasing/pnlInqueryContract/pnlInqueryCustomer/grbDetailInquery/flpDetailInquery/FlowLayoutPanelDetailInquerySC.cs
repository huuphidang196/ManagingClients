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

        protected Label _lblNameInquery;
        public Label LblNameInquery => _lblNameInquery;

        protected Label _lblNumberInquery;
        public Label LblNumberInquery => _lblNumberInquery;

        protected Label _lblMinTimeDurationShip;
        public Label LblMinTimeDurationShip => _lblMinTimeDurationShip;

        protected Label _lblMaxTimeDurationShip;
        public Label TxtMaxTimeDurationShip => _lblMaxTimeDurationShip;

        protected Label _lblSelected_Exchange_Rate;
        public Label LblSelectedExchangeRate => _lblSelected_Exchange_Rate;

        protected Label _lblPurposePurchasing;
        public Label LblPurposePurchasing => _lblPurposePurchasing;

        protected Label _lblEndUser;
        public Label LblEndUser => _lblEndUser;


        protected DateTimePicker _dtpDateSendInquery;
        public DateTimePicker DtpDateSendInquery => _dtpDateSendInquery;

        protected DateTimePicker _dtpDateExpiredInquery;
        public DateTimePicker DtpDateExpiredInquery => _dtpDateExpiredInquery;

        protected Label _lblShowFileInquery;

        protected Button _btnOpenDetailInforInquery;
        protected Button _btnDeleteFileInquery;
        protected Button _btnDeleteInqueryQuotation;
        protected Button _btnSaveInquery;

        public FlowLayoutPanelDetailInquerySC()
        {
            // this._InqueryQuotation = new InqueryQuotation();
            this._flowDetailInquery = FrmDetailCustomer.Instance.flpDetailInquery;
            this._lblNameInquery = FrmDetailCustomer.Instance.lblNameInquery;

            this._lblNumberInquery = FrmDetailCustomer.Instance.lblInqueryNumber;

            this._lblMinTimeDurationShip = FrmDetailCustomer.Instance.lblMinTimeDurationShip;
            this._lblMaxTimeDurationShip = FrmDetailCustomer.Instance.lblMaxTimeDurationShip;
            this._lblSelected_Exchange_Rate = FrmDetailCustomer.Instance.lblSelectedExchangeRate;

            this._lblPurposePurchasing = FrmDetailCustomer.Instance.lblPurposePurchasing;
            this._lblEndUser = FrmDetailCustomer.Instance.lblEndUser;

            this._dtpDateSendInquery = FrmDetailCustomer.Instance.dtpDateSendInquery;
            this._dtpDateSendInquery.Enabled = false;

            this._dtpDateExpiredInquery = FrmDetailCustomer.Instance.dtpDateExpiredInquery;
            this._dtpDateExpiredInquery.Enabled = false;

            this._lblShowFileInquery = FrmDetailCustomer.Instance.lblShowFileInquery;
            this._lblShowFileInquery.Click += new EventHandler(ShowFileOrAddFilePDF);

            this._btnDeleteFileInquery = FrmDetailCustomer.Instance.btnDeleteFileInquery;
            this._btnDeleteFileInquery.Click += new EventHandler(AddEventClearFileInqueryButton);

            this._btnOpenDetailInforInquery = FrmDetailCustomer.Instance.btnDetailInqueryInfor;
            this._btnOpenDetailInforInquery.Click += new EventHandler(this.AddEventDetailInquery);

            this._btnSaveInquery = FrmDetailCustomer.Instance.btnSaveInquery;
            this._btnSaveInquery.Click += new EventHandler(this.AddEventSaveInqueryButton);

            this._btnDeleteInqueryQuotation = FrmDetailCustomer.Instance.btnRemoveInquery;
            this._btnDeleteInqueryQuotation.Click += new EventHandler(AddEventClearAllDataInqueryButton);

            this.ClearContentOfControl();
            this.ActiveOrUnActiveAllControl(false);

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

        protected virtual void AddEventDetailInquery(object sender, EventArgs e)
        {
            CustomerOrder customerOrder_Of_Inquery = PanelCenterCusICSC.Instance.PanelOrderPurchasingCustomerSC.PanelSettingOrderPurchasingSC.GrbSettingOrderPurchasingSC.CustomerOrder_Creating;

            if (!this.CheckOrderCustomerIsExistent(customerOrder_Of_Inquery)) return;

            this._InqueryQuotation.ID_Customer_Order = customerOrder_Of_Inquery.ID_Customer_Order;
            //if (fr)
            frmMerchandise.Instance.SetInqueryQuotation(this._InqueryQuotation);
            DialogResult ret = frmMerchandise.Instance.ShowDialog();

            if (ret == DialogResult.Yes) this._InqueryQuotation = frmMerchandise.Instance.InqueryQuotation;
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

        #endregion

        #region Internal_Function
        protected virtual bool ProcessEventSaveInquery()
        {
            //Get CustomerOrder was generated
            CustomerOrder customerOrder_Of_Inquery = PanelCenterCusICSC.Instance.PanelOrderPurchasingCustomerSC.PanelSettingOrderPurchasingSC.GrbSettingOrderPurchasingSC.CustomerOrder_Creating;

            if (!this.CheckOrderCustomerIsExistent(customerOrder_Of_Inquery)) return false;

            this._InqueryQuotation.ID_Customer_Order = customerOrder_Of_Inquery.ID_Customer_Order;

            if (this._InqueryQuotation.File_Data_Inquiry_Quotation == null)
            {
                MessageBox.Show("Vui lòng đính kèm tệp PDF File Báo Giá");
                return false;
            }

            bool saveSuccess = CustomerOrderDataProvider.Instance.InsertInqueryQuotation(this._InqueryQuotation);
            string str_Result = saveSuccess ? "Lưu Báo giá thành công! " : "Lưu thất bại";
            MessageBox.Show(str_Result);

            if (saveSuccess)
            {
                frmMerchandise.Instance.SetInqueryQuotation(this._InqueryQuotation);
                this.ActiveOrUnActiveAllControl(false);
            } 
            //setting co
            //Save together
            PanelCenterCusICSC.Instance.PanelOrderPurchasingCustomerSC.PanelSettingOrderPurchasingSC.GrbSettingOrderPurchasingSC.ActiveOrUnActiveAllControl(false);
            return true;
        }

        protected virtual bool CheckOrderCustomerIsExistent(CustomerOrder customerOrder_Of_Inquery)
        {
            if (customerOrder_Of_Inquery.ID_Customer_Order == 0)
            {
                MessageBox.Show("Vui lòng Thiết lập Đơn Hàng trước ở Panel phía trên trước");
                return false;
            }
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

            this._lblNameInquery.Text = inqueryQuotation.Name_Inquiry_Quotation;
            this._lblNumberInquery.Text = inqueryQuotation.Number_Inquiry_Quotation;
            this._lblMinTimeDurationShip.Text = inqueryQuotation.Min_Time_Delivery.ToString();
            this._lblMaxTimeDurationShip.Text = inqueryQuotation.Max_Time_Delivery.ToString();
            this._lblSelected_Exchange_Rate.Text = inqueryQuotation.Selected_Exchange_Rate.ToString();
            this._lblPurposePurchasing.Text = inqueryQuotation.Purpose_Purchasing;
            this._lblEndUser.Text = inqueryQuotation.Name_Of_EndUser;

            this._dtpDateSendInquery.Value = (inqueryQuotation.Date_Sending <= DateTime.MinValue) ? DateTime.Today : inqueryQuotation.Date_Sending;
            this._dtpDateExpiredInquery.Value = (inqueryQuotation.Date_Expired_Time_Inquiry <= DateTime.MinValue) ? DateTime.Today : inqueryQuotation.Date_Expired_Time_Inquiry;

            this._lblShowFileInquery.Text = (inqueryQuotation.File_Data_Inquiry_Quotation == null) ? "Tải file PDF" : "File Báo giá";
        }
        protected virtual void ClearFileInquery()
        {

            this._lblShowFileInquery.Text = "Tải file PDF";

            this._InqueryQuotation.File_Data_Inquiry_Quotation = null;
        }

        protected virtual void ActiveOrUnActiveAllControl(bool active)
        {
            this._lblShowFileInquery.Enabled = active;

            this._btnDeleteFileInquery.Visible = active;
            this._btnSaveInquery.Visible = active;
            this._btnDeleteInqueryQuotation.Visible = active;
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
