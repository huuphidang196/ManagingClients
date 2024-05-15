using ManagingClients._Data.Scripts.DAO.Scene_Manage_Customer.pnlMainControl.pnlDisplayOverall.pnlPurchasingOrder;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder.pnlBottomDisplay.TabControlPO.TabControlPODSKH
{
    public class TabControlDSKHSC
    {
        public DataGridView _dgvDisplayAllCusPO;
        public DataGridView dgvDisplayAllCusPO => _dgvDisplayAllCusPO;

        public TabControlDSKHSC()
        {
            this._dgvDisplayAllCusPO = frmMain_Control.Instance.dgvDisplayAllCusPO;
            this._dgvDisplayAllCusPO.CellDoubleClick += DataGridView_CellDoubleClick;
            this.ShowAllListCustomer();
        }
        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện double-click tại đây
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dgvDisplayAllCusPO.Rows[e.RowIndex].Cells[e.ColumnIndex];
                MessageBox.Show($"Double-clicked cell value: {cell.Value}");
            }
        }


        public virtual void ShowAllListCustomer()
        {
            DataTable dataTable = PurchasingOrderProvider.Instance.GetDataTableAllCustomer();

            this._dgvDisplayAllCusPO.DataSource = dataTable;

            //recify column name
            this._dgvDisplayAllCusPO.Columns["ID_Customer"].HeaderText = "ID Khách Hàng";
            this._dgvDisplayAllCusPO.Columns["Name_Customer"].HeaderText = "Tên Khách hàng";
            this._dgvDisplayAllCusPO.Columns["Address_Company"].HeaderText = "Địa chỉ Công Ty";
            this._dgvDisplayAllCusPO.Columns["Address_Email"].HeaderText = "Email Công Ty";
            this._dgvDisplayAllCusPO.Columns["Phone_Number"].HeaderText = "Số điện thoại";
            this._dgvDisplayAllCusPO.Columns["Tax_Number"].HeaderText = "Mã số thuế";
            // Tiếp tục cho tất cả các cột cần đổi tên
            foreach (DataGridViewColumn column in this._dgvDisplayAllCusPO.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //Sort A -> Z
            this.SortObjectByCondition(SortingMethod.Sort_By_ID);
        }

        public virtual void SortObjectByCondition(SortingMethod sortingMethod)
        {
            DataTable dt = this._dgvDisplayAllCusPO.DataSource as DataTable;
            if (dt == null) return;

            string columnSort = "";
            switch (sortingMethod)
            {
                case SortingMethod.Sort_By_ID:
                    columnSort = "ID_Customer ASC";
                    break;
                case SortingMethod.Sort_A_Z:
                    columnSort = "Name_Customer ASC";
                    break;
                case SortingMethod.Sort_Z_A:
                    columnSort = "Name_Customer DESC";
                    break;
                case SortingMethod.Total_Contract:
                    break;
                case SortingMethod.Total_Value_Inquery:
                    break;
                case SortingMethod.Total_Value_Contract_Signed:
                    break;
                default:
                    break;
            }
            dt.DefaultView.Sort = columnSort;
            this._dgvDisplayAllCusPO.DataSource = dt;
        }
    }
}
