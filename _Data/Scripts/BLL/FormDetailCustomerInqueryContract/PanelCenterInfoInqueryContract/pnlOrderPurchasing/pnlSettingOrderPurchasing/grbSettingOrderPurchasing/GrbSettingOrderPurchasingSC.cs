using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer;
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

        protected GroupBox _grbSettingOrderPurchasing;


        protected TextBox _txtNameOrder;

        protected ComboBox _cboStatusOrder;

        protected ComboBox _cboLevelPosAccessOrder;

        protected ComboBox _cboLevelCompanyAccessOrder;

        public GrbSettingOrderPurchasingSC()
        {
            this._CustomerOrder = new CustomerOrder();

            this._grbSettingOrderPurchasing = FrmDetailCustomer.Instance.grbSettingOrderPurchasing;

            this._txtNameOrder = FrmDetailCustomer.Instance.txtNameOrder;
            // this.

            this._cboStatusOrder = FrmDetailCustomer.Instance.cboStatusOrder;
            this._cboLevelPosAccessOrder = FrmDetailCustomer.Instance.cboLevelPosAccessOrder;
            this._cboLevelCompanyAccessOrder = FrmDetailCustomer.Instance.cboLevelCompanyAccessOrder;

            this.InitilizingAllValue();
        }
        #region Add_Events
        protected virtual void AddEventOfListViewCustomerOrderSelectedChange(CustomerOrder customerOrder)
        {
            this._txtNameOrder.Text = customerOrder.Name_Order;
            this._cboStatusOrder.SelectedIndex = (int)customerOrder.Status_Order;
            this._cboLevelPosAccessOrder.SelectedIndex = (int)customerOrder.Level_Pos_Access_Order;
            this._cboLevelCompanyAccessOrder.SelectedIndex = (int)customerOrder.Level_Access_Order;

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

        protected virtual void ClearContentOfControl()
        {
            this._txtNameOrder.Text = "";

            this._CustomerOrder = new CustomerOrder();

            this._cboStatusOrder.SelectedIndex = 0;
            this._cboLevelPosAccessOrder.SelectedIndex = 0;
            this._cboLevelCompanyAccessOrder.SelectedIndex = 0;
        }
        #endregion

        #region Reference_outside
        public virtual void CreatNewInqueryAndContractOfCustomer()
        {
            this.ClearContentOfControl();
        }
        #endregion
    }
}
