using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.pnlBelowCusIC;
using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer;
using ManagingClients._Data.Scripts.DAO.FormDetailCustomerIC;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlOrderPurchasing.pnlSettingOrderPurchasing.grbSettingOrderPurchasing
{
    public class GrbSettingOrderPurchasingSC
    {
        protected CustomerOrder _CustomerOrder;
        public CustomerOrder CustomerOrder_Creating => _CustomerOrder;

        protected GroupBox _grbSettingOrderPurchasing;


        protected TextBox _txtNameOrder;

        protected ComboBox _cboStatusOrder;

        protected ComboBox _cboLevelPosAccessOrder;

        protected ComboBox _cboLevelCompanyAccessOrder;

        protected Button _btnSaveSettingCusOrder;

        public GrbSettingOrderPurchasingSC()
        {
            this._CustomerOrder = new CustomerOrder();

            this._grbSettingOrderPurchasing = FrmDetailCustomer.Instance.grbSettingOrderPurchasing;

            this._txtNameOrder = FrmDetailCustomer.Instance.txtNameOrder;
            // this.

            this._cboStatusOrder = FrmDetailCustomer.Instance.cboStatusOrder;
            this._cboStatusOrder.DropDownStyle = ComboBoxStyle.DropDownList;

            this._cboLevelPosAccessOrder = FrmDetailCustomer.Instance.cboLevelPosAccessOrder;
            this._cboLevelPosAccessOrder.DropDownStyle = ComboBoxStyle.DropDownList;

            this._cboLevelCompanyAccessOrder = FrmDetailCustomer.Instance.cboLevelCompanyAccessOrder;
            this._cboLevelCompanyAccessOrder.DropDownStyle = ComboBoxStyle.DropDownList;

            this._btnSaveSettingCusOrder = FrmDetailCustomer.Instance.btnSaveSettingCusOrder;
            this._btnSaveSettingCusOrder.Click += new EventHandler(this.AddEventClickForSaveButtonOfCustomerOrder);

            this.InitilizingAllValue();
            this.ActiveOrUnActiveAllControl(false);

        }

        #region Add_Events
        protected virtual void AddEventClickForSaveButtonOfCustomerOrder(object sender, EventArgs e)
        {
            //Check Customer have info
            CustomerGSES customerGSES_Checked = FrmDetailCustomer.Instance.CustomerGSES;

            if (customerGSES_Checked.ID_Customer == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin Khách Hàng trước");
                return;
            }

            this.ProcessEventSaveCustomerOrder();
        }
        #endregion

        #region Internal_Function

        protected virtual void InitilizingAllValue()
        {
            this.InitializingValueComboBoxStatusOrder();

            this.InitializingValueComboBoxLevelPosAccess();

            this.InitializingValueComboBoxLevelCompanyAccess();
        }

        protected virtual void InitializingValueComboBoxStatusOrder()
        {
            // MessageBox.Show("Ini");
            this._cboStatusOrder.Items.Clear();

            // Gán các giá trị enum vào ComboBox
            foreach (StatusOrder status in Enum.GetValues(typeof(StatusOrder)))
            {
                string content = TransferEnumString.TransferStatusOrderToString(status);
                this._cboStatusOrder.Items.Add(content);
            }
            //MessageBox.Show(this._cboStatusOrder.Items[0].ToString());
            // Tùy chọn: Đặt giá trị mặc định được chọn cho ComboBox
            if (this._cboStatusOrder.Items.Count > 0)
            {
                this._cboStatusOrder.SelectedIndex = 0; // Chọn mục đầu tiên
            }
        }
        protected virtual void InitializingValueComboBoxLevelPosAccess()
        {
            this._cboLevelPosAccessOrder.Items.Clear();

            // Gán các giá trị enum vào ComboBox
            foreach (Position pos in Enum.GetValues(typeof(Position)))
            {
                string content = TransferEnumString.TransferPostionToString(pos);

                this._cboLevelPosAccessOrder.Items.Add(content);
            }

            // Tùy chọn: Đặt giá trị mặc định được chọn cho ComboBox
            if (this._cboLevelPosAccessOrder.Items.Count > 0)
            {
                this._cboLevelPosAccessOrder.SelectedIndex = 0; // Chọn mục đầu tiên
            }
        }
        protected virtual void InitializingValueComboBoxLevelCompanyAccess()
        {
            this._cboLevelCompanyAccessOrder.Items.Clear();

            // Gán các giá trị enum vào ComboBox
            foreach (LevelAccess level in Enum.GetValues(enumType: typeof(LevelAccess)))
            {
                string content = TransferEnumString.TransferLevelAccessToString(level);
                this._cboLevelCompanyAccessOrder.Items.Add(content);
            }

            // Tùy chọn: Đặt giá trị mặc định được chọn cho ComboBox
            if (this._cboLevelCompanyAccessOrder.Items.Count > 0)
            {
                this._cboLevelCompanyAccessOrder.SelectedIndex = 0; // Chọn mục đầu tiên
            }
        }

        public virtual void ActiveOrUnActiveAllControl(bool active)
        {
            if (this._txtNameOrder == null)
            {
                this._txtNameOrder = FrmDetailCustomer.Instance.txtNameOrder;
            }
            if (this._cboStatusOrder == null)
            {
                this._cboStatusOrder = FrmDetailCustomer.Instance.cboStatusOrder;
            }
            if (this._cboLevelPosAccessOrder == null)
            {
                this._cboLevelPosAccessOrder = FrmDetailCustomer.Instance.cboLevelPosAccessOrder;
            }
            if (this._cboLevelCompanyAccessOrder == null)
            {
                this._cboLevelCompanyAccessOrder = FrmDetailCustomer.Instance.cboLevelCompanyAccessOrder;
            }
            if (this._btnSaveSettingCusOrder == null)
            {
                this._btnSaveSettingCusOrder = FrmDetailCustomer.Instance.btnSaveSettingCusOrder;
            }

            this._txtNameOrder.ReadOnly = !active;
            this._cboStatusOrder.Enabled = active;
            this._cboLevelPosAccessOrder.Enabled = active;
            this._cboLevelCompanyAccessOrder.Enabled = active;
            this._btnSaveSettingCusOrder.Visible = active;
        }
        protected virtual void SetContentControlByCustomerOrder(CustomerOrder customerOrder)
        {
            this._CustomerOrder = customerOrder;

            this._txtNameOrder.Text = customerOrder.Name_Order;
            this._cboStatusOrder.SelectedIndex = (int)customerOrder.Status_Order;
            this._cboLevelPosAccessOrder.SelectedIndex = (int)customerOrder.Level_Pos_Access_Order;
            this._cboLevelCompanyAccessOrder.SelectedIndex = (int)customerOrder.Level_Access_Order;


        }
        protected virtual void ClearContentOfControl()
        {
            this._txtNameOrder.Text = "";

            this._CustomerOrder = new CustomerOrder();
            this._CustomerOrder.ID_Customer = FrmDetailCustomer.Instance.CustomerGSES.ID_Customer;
            this._CustomerOrder.Name_Log_In = FrmMain_Control.Instance.ProfileAccount.Name_Log_In;

            this._cboStatusOrder.SelectedIndex = 0;
            this._cboLevelPosAccessOrder.SelectedIndex = 0;
            this._cboLevelCompanyAccessOrder.SelectedIndex = 0;
        }


        protected virtual CustomerOrder GetCustomerOrderAssembleDataOnControl()
        {
            CustomerOrder customerOrder = new CustomerOrder();

            customerOrder.ID_Customer_Order = this._CustomerOrder.ID_Customer_Order;
            customerOrder.Name_Order = this._txtNameOrder.Text;
            customerOrder.Name_Log_In = this._CustomerOrder.Name_Log_In;
            customerOrder.Status_Order = (StatusOrder)this._cboStatusOrder.SelectedIndex;
            customerOrder.Level_Pos_Access_Order = (Position)this._cboLevelPosAccessOrder.SelectedIndex;
            customerOrder.Level_Access_Order = (LevelAccess)this._cboLevelCompanyAccessOrder.SelectedIndex;

            customerOrder.ID_Customer = this._CustomerOrder.ID_Customer;
            customerOrder.Name_Log_In = FrmMain_Control.Instance.ProfileAccount.Name_Log_In;
            return customerOrder;
        }
        #endregion

        #region Reference_outside
        public virtual void CreatNewInqueryAndContractOfCustomerAndSetSetting()
        {
            this.AllowEditCustomerOrder();
            this.ClearContentOfControl();
        }

        public virtual void ListViewCustomerOrderChangeSelected(CustomerOrder customerOrder)
        {
            this.ActiveOrUnActiveAllControl(customerOrder.ID_Customer_Order == 0);

            this.SetContentControlByCustomerOrder(customerOrder);
        }

        public virtual void AllowEditCustomerOrder()
        {
            this.ActiveOrUnActiveAllControl(true);
        }
        public virtual void ProcessEventSaveCustomerOrder()
        {
            this._CustomerOrder = this.GetCustomerOrderAssembleDataOnControl();
            CustomerOrderDataProvider.Instance.InsertCustomerOrder(this._CustomerOrder);

            //Don't allow user interact
            this.ActiveOrUnActiveAllControl(false);

            this._CustomerOrder.ID_Customer_Order = CustomerOrderDataProvider.Instance.GetMaxIDCustomerOrder();
            this._CustomerOrder = CustomerOrderDataProvider.Instance.GetCustomerOrderOfCustomerByIDCustomerOrder(this._CustomerOrder.ID_Customer_Order);

            //Save Inquery and Contract Together
            bool saveInquery = PanelCenterCusICSC.Instance.PanelOrderPurchasingCustomerSC.PanelInqueryContractSC.
                PanelInqueryCustomerSC.FlowLayoutPanelDetailInquerySC.SaveInqueryCustomerOrderTogether();

            bool saveContract = PanelCenterCusICSC.Instance.PanelOrderPurchasingCustomerSC.PanelInqueryContractSC.
                PanelContractCustomerSC.GroupBoxDetailContractSC.FlowLayoutPanelDetailContractSC.SaveContractCustomerOrderTogether();

            if (!saveInquery || !saveContract) return;

            PanelBelowCusICSC.Instance.TabCtrlInqueryContractSC.TabPageInqueryCustomerSC.ShowAndSetSelectedItem();
        }
        public virtual void ProcessGroupCustomerOrderSettingAfterGenerateNewCustomer()
        {
            this.ClearContentOfControl();
        }
        #endregion
    }
}
