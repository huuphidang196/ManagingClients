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
        protected Button _btnRemoveContract;

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
            this._btnSaveContract.Click += new EventHandler(this.AddEventContractButton);

            this._btnRemoveContract = FrmDetailCustomer.Instance.btnRemoveContract;
            this._btnRemoveContract.Click += new EventHandler(AddEventClearAllDataContractButton);

            this.ClearContentOfControl();
            this.ActiveOrUnActiveAllControl(false);

            this._txtTotalValueContract.Leave += new EventHandler(this.AddEventCheckTextBoxNumberValidAfterPress);

        }


        #region Add_Events
        protected virtual void AddEventClearAllDataContractButton(object sender, EventArgs e)
        {

            this.ClearContentOfControl();
        }
        protected virtual void AddEventDoubleClickForLabelFileContract(object sender, EventArgs e)
        {
            if (this._lblFileContract.Enabled == false) return;

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

        protected virtual void AddEventContractButton(object sender, EventArgs e)
        {
            this.ProcessEventSaveContract();
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
        protected virtual void AddEventDeleteFileContract()
        {
            this.ClearFileContractAndlabelContract();
        }
        protected virtual void ProcessEventSaveContract()
        {
            //Get CustomerOrder was generated
            CustomerOrder customerOrder_Of_Inquery = PanelCenterCusICSC.Instance.PanelOrderPurchasingCustomerSC.PanelSettingOrderPurchasingSC.GrbSettingOrderPurchasingSC.CustomerOrder_Creating;

            if (customerOrder_Of_Inquery.ID_Customer_Order == 0)
            {
                MessageBox.Show("Vui lòng Thiết lập Đơn Hàng trước ở Panel phía trên trước");
                return;
            }

            this._ContractCustomer = this.GetContractCustomerAssembleDataOnControl();
            this._ContractCustomer.ID_Customer_Order = customerOrder_Of_Inquery.ID_Customer_Order;

            bool saveSuccess = CustomerOrderDataProvider.Instance.InsertCustomerContract(this._ContractCustomer);
            string str_Result = saveSuccess ? "Lưu Hợp Đồng thành công! " : "Lưu thất bại";
            MessageBox.Show(str_Result);

            if (saveSuccess) this.ActiveOrUnActiveAllControl(false);

            //Save together
            PanelCenterCusICSC.Instance.PanelOrderPurchasingCustomerSC.PanelSettingOrderPurchasingSC.GrbSettingOrderPurchasingSC.ActiveOrUnActiveAllControl(false);
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
        protected virtual void ActiveOrUnActiveAllControl(bool active)
        {
            this._txtNumberContract.ReadOnly = !active;
            this._txtTotalValueContract.ReadOnly = !active;

            this._dtpDateSigned.Enabled = active;
            this._dtpDateExpired.Enabled = active;
            this._lblFileContract.Enabled = active;

            this._btnDeleteFileContract.Visible = active;
            this._btnSaveContract.Visible = active;
            this._btnRemoveContract.Visible = active;
        }
        protected virtual ContractCustomer GetContractCustomerAssembleDataOnControl()
        {
            ContractCustomer contractCus = new ContractCustomer();

            contractCus.ID_Contract_Customer = this._ContractCustomer.ID_Contract_Customer;
            contractCus.Number_Contract = this._txtNumberContract.Text;
            contractCus.Signed_Time = this._dtpDateSigned.Value;
            contractCus.Expired_Time = this._dtpDateExpired.Value;
            contractCus.Total_Contract_Value = decimal.Parse(this._txtTotalValueContract.Text);
            contractCus.File_Data_Contract = this._ContractCustomer.File_Data_Contract;

            // contractCus.ID_Customer_Order 

            return contractCus;
        }
        #endregion

        #region Outside_Reference
        public virtual void CreatNewContractOfCustomer()
        {
            this.AllowEditCustomerOrder();
            this.ClearContentOfControl();
        }
        public virtual void ListViewCustomerOrderChangeSelected(CustomerOrder customerOrder)
        {
            this.ActiveOrUnActiveAllControl(customerOrder.ID_Customer_Order == 0);

            this._ContractCustomer = CustomerOrderDataProvider.Instance.GetContractQuotationrOrderOfCustomerByIDCustomerOrder(customerOrder.ID_Customer_Order);
            this.SetContentControlByInquery(this._ContractCustomer);

        }
        public virtual void AllowEditCustomerOrder()
        {
            this.ActiveOrUnActiveAllControl(true);
        }
        #endregion
    }
}
