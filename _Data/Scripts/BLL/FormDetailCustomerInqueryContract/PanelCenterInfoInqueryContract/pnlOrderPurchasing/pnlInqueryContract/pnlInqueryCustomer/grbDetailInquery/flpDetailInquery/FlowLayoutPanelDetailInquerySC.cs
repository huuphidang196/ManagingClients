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

        public FlowLayoutPanelDetailInquerySC()
        {
            this._InqueryQuotation = new InqueryQuotation();

            this._txtNameInquery = frmDetailCustomer.Instance.txtNameInquery;
            this._flowDetailInquery = frmDetailCustomer.Instance.flpDetailInquery;

            this._txtNumberInquery = frmDetailCustomer.Instance.txtInqueryNumber;
            this._txtCostDeliveryVN = frmDetailCustomer.Instance.txtCostDeliveryVN;
            this._txtCostDeliveryKH = frmDetailCustomer.Instance.txtCostDeliveryKH;
            this._txtMinTimeDurationShip = frmDetailCustomer.Instance.txtMinTimeDurationShip;
            this._txtMaxTimeDurationShip = frmDetailCustomer.Instance.txtMaxTimeDurationShip;
            this._txtSelected_Exchange_Rate = frmDetailCustomer.Instance.txtSelectedExchangeRate;
            this._txtPurposePurchasing = frmDetailCustomer.Instance.txtPurposePurchasing;
            this._txtEndUser = frmDetailCustomer.Instance.txtEndUser;

            this._dtpDateSendInquery = frmDetailCustomer.Instance.dtpDateSendInquery;
            this._dtpDateExpiredInquery = frmDetailCustomer.Instance.dtpDateExpiredInquery;

            this._lblShowFileInquery = frmDetailCustomer.Instance.lblShowFileInquery;
            this._lblShowFileInquery.Click += new EventHandler(ShowFileOrAddFilePDF);

            this._btnDeleteFileInquery = frmDetailCustomer.Instance.btnDeleteFileInquery;
            this._btnDeleteFileInquery.Click += new EventHandler(AddEventClearInqueryButton);
        }

        public virtual void ChangeInqueryQuotationSelected(InqueryQuotation inqueryQuotation) => this._InqueryQuotation = inqueryQuotation;

        #region Add_Event
        protected virtual void ShowFileOrAddFilePDF(object sender, EventArgs e)
        {
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
        protected virtual void AddEventClearInqueryButton(object sender , EventArgs e)
        {
            this.ClearFileInquery();
        }
        #endregion

        #region Internal_Function
        protected virtual void ClearContentOfControl()
        {
            this._txtNameInquery.Text = "";
            this._txtNumberInquery.Text = "";
            this._txtCostDeliveryVN.Text = "";
            this._txtCostDeliveryKH.Text = "";
            this._txtMinTimeDurationShip.Text = "";
            this._txtMaxTimeDurationShip.Text = "";
            this._txtSelected_Exchange_Rate.Text = "";
            this._txtPurposePurchasing.Text = "";
            this._txtEndUser.Text = "";

            this.ClearFileInquery();
            this._InqueryQuotation = new InqueryQuotation();
            //Listview selected = 0

        }
        protected virtual void ClearFileInquery()
        {

            this._lblShowFileInquery.Text = "Tải file PDF";

            this._InqueryQuotation.File_Data_Inquiry_Quotation = null;
        }
        #endregion

        #region Outside_Reference
        public virtual void CreatNewInqueryOfCustomer()
        {
            this.ClearContentOfControl();
        }
        #endregion

    }
}
