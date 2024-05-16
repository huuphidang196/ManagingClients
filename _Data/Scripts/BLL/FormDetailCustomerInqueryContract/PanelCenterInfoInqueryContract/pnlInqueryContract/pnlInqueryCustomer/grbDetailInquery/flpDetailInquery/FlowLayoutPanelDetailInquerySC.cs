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

        protected TextBox _txtBenefitPercent;
        public TextBox TxtBenefitPercent => _txtBenefitPercent;

        protected DateTimePicker _dtpDateSendInquery;
        public DateTimePicker DtpDateSendInquery => _dtpDateSendInquery;

        protected DateTimePicker _dtpDateExpiredInquery;
        public DateTimePicker DtpDateExpiredInquery => _dtpDateExpiredInquery;

        protected Label _lblShowFileInquery;

        protected Button _btnDeleteFileInquery;

        public FlowLayoutPanelDetailInquerySC()
        {
            this._InqueryQuotation = new InqueryQuotation();

            this._flowDetailInquery = frmDetailCustomer.Instance.flpDetailInquery;

            this._txtNumberInquery = frmDetailCustomer.Instance.txtInqueryNumber;
            this._txtCostDeliveryVN = frmDetailCustomer.Instance.txtCostDeliveryVN;
            this._txtCostDeliveryKH = frmDetailCustomer.Instance.txtCostDeliveryKH;
            this._txtMinTimeDurationShip = frmDetailCustomer.Instance.txtMinTimeDurationShip;
            this._txtMaxTimeDurationShip = frmDetailCustomer.Instance.txtMaxTimeDurationShip;
            this._txtBenefitPercent = frmDetailCustomer.Instance.txtBenefitPercent;

            this._dtpDateSendInquery = frmDetailCustomer.Instance.dtpDateSendInquery;
            this._dtpDateExpiredInquery = frmDetailCustomer.Instance.dtpDateExpiredInquery;

            this._lblShowFileInquery = frmDetailCustomer.Instance.lblShowFileInquery;
            this._lblShowFileInquery.Click += new EventHandler(ShowFileOrAddFilePDF);
            this._btnDeleteFileInquery = frmDetailCustomer.Instance.btnDeleteFileInquery;

        }

        public virtual void ChangeInqueryQuotationSelected(InqueryQuotation inqueryQuotation) => this._InqueryQuotation = inqueryQuotation;

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
        public virtual void CreatNewInqueryOfCustomer()
        {
            this.ClearTextBoxInControl();
        }

        protected virtual void ClearTextBoxInControl()
        {
            this._txtNumberInquery.Text = "";
            this._txtCostDeliveryVN.Text = "";
            this._txtCostDeliveryKH.Text = "";
            this._txtMinTimeDurationShip.Text = "";
            this._txtMaxTimeDurationShip.Text = "";
            this._txtBenefitPercent.Text = "";

            this._lblShowFileInquery.Text = "Tải file PDF";
        }
    }
}
