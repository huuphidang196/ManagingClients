using ManagingClients._Data.Scripts.DAO.FormDetailCustomerIC;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlInqueryContract.pnlContractCustomer.grbDetailContract.flpDetailContract
{
    public class FlowLayoutPanelDetailContractSC
    {
        public ContractCustomer _ContractCustomer;

        protected TextBox _txtNumberContract;

        protected DateTimePicker _dtpDateSigned;

        protected DateTimePicker _dtpDateExpired;

        protected TextBox _txtTotalValueContract;

        protected Label _lblFileContract;

        protected Button _btnDeleteFileContract;

        protected Button _btnSaveContract;

        public FlowLayoutPanelDetailContractSC()
        {
            this._ContractCustomer = new ContractCustomer();

            this._txtNumberContract = FrmDetailCustomer.Instance.txtNumberContract;
            this._dtpDateSigned = FrmDetailCustomer.Instance.dtpDateSigned;
            this._dtpDateExpired = FrmDetailCustomer.Instance.dtpDateExpired;
            this._txtTotalValueContract = FrmDetailCustomer.Instance.txtTotalValueContract;

            this._lblFileContract = FrmDetailCustomer.Instance.lblFileContract;
            this._lblFileContract.DoubleClick += new EventHandler(this.AddEventDoubleClickForLabelFileContract);

            this._btnDeleteFileContract = FrmDetailCustomer.Instance.btnDeleteFileContract;
            this._btnDeleteFileContract.Click += new EventHandler(this.AddEventClickForButtonDeletedFileContract);

            this._btnSaveContract = FrmDetailCustomer.Instance.btnSaveContract;
            this._btnSaveContract.Click += new EventHandler(this.AddEventClickForButtonSaveContract);

            this.ClearContentOfControl();
        }


        #region Add_Events
        protected virtual void AddEventDoubleClickForLabelFileContract(object sender, EventArgs e)
        {

            if (this._ContractCustomer.File_Data_Contract == null)
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

                        this._ContractCustomer.File_Data_Contract = fileBytes;
                        this._lblFileContract.Text = fileName;
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
            frmPDFFileReader.SetFileNameByte(this._ContractCustomer.File_Data_Contract);
            frmPDFFileReader.Show();
        }

        protected virtual void AddEventClickForButtonDeletedFileContract(object sender, EventArgs e)
        {
            this.AddEventDeleteFileContract();
        }
        protected virtual void AddEventClickForButtonSaveContract(object sender, EventArgs e)
        {
            this.AddEventSaveContract();
        }
        #endregion

        #region Internal_Function
        protected virtual void AddEventDeleteFileContract()
        {
            this.ClearFileContractAndlabelContract();
        }

        protected virtual void AddEventSaveContract()
        {
            this._ContractCustomer.Number_Contract = this._txtNumberContract.Text;
            this._ContractCustomer.Signed_Time = this._dtpDateSigned.Value;
            this._ContractCustomer.Expired_Time = this._dtpDateExpired.Value;
            this._ContractCustomer.Total_Contract_Value = int.Parse(this._txtTotalValueContract.Text);
            // this._ContractCustomer.
        }
        protected virtual void ClearContentOfControl()
        {
            this._ContractCustomer = new ContractCustomer();

            this.SetContentControlByInquery(this._ContractCustomer);

            this.ClearFileContractAndlabelContract();

            //Listview selected = 0

        }
        protected virtual void SetContentControlByInquery(ContractCustomer contractCustomer)
        {
            this._txtNumberContract.Text = contractCustomer.Number_Contract;
            this._txtTotalValueContract.Text = contractCustomer.Total_Contract_Value.ToString();

            this._dtpDateSigned.Value = (contractCustomer.Signed_Time <= DateTime.MinValue) ? DateTime.Today : contractCustomer.Signed_Time;
            this._dtpDateExpired.Value = (contractCustomer.Expired_Time <= DateTime.MinValue) ? DateTime.Today : contractCustomer.Expired_Time;

            this._lblFileContract.Text = (contractCustomer.File_Data_Contract == null) ? "Tải file PDF" : "File Hợp Đồng";
        }
        protected virtual void ClearFileContractAndlabelContract()
        {
            this._lblFileContract.Text = "Tải File PDF đính kèm";

            this._ContractCustomer.File_Data_Contract = null;
        }
        #endregion

        #region Outside_Reference
        public virtual void CreatNewContractOfCustomer()
        {
            this.ClearContentOfControl();
        }
        public virtual void ListViewCustomerOrderChangeSelected(CustomerOrder customerOrder)
        {
            this._ContractCustomer = CustomerOrderDataProvider.Instance.GetContractQuotationrOrderOfCustomerByIDCustomerOrder(customerOrder.ID_Customer_Order);
            this.SetContentControlByInquery(this._ContractCustomer);
        }
        #endregion
    }
}
