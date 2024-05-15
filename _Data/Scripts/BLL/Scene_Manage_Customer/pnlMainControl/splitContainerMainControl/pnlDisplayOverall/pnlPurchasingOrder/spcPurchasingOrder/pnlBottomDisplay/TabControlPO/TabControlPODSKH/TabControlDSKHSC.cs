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

             this.ShowAllListCustomer();
            // this.UpdateRowNumbers();
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
             this.SortObjectByCondition(SortingMethod.Sort_A_Z);
            //this.AddRowNumberColumn();
            this.UpdateRowNumbers();
        }
        protected virtual void AddRowNumberColumn()
        {
            
            // Kiểm tra xem cột "STT" đã tồn tại chưa
            if (this._dgvDisplayAllCusPO.Columns["STT"] != null) return;

            // Thêm cột mới vào DataGridView
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
            {
                HeaderText = "STT",
                Name = "STT",

            };
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this._dgvDisplayAllCusPO.Columns.Insert(0, column);

        }

        public virtual void UpdateRowNumbers()
        {
          
            // Đảm bảo cột STT đã tồn tại
            this.AddRowNumberColumn();

            if (this._dgvDisplayAllCusPO.Columns["STT"] != null)
                //MessageBox.Show("existed, row = " + this._dgvDisplayAllCusPO.Rows.Count);

            // Chạy vòng lặp qua tất cả các hàng trong DataGridView và gán giá trị số thứ tự
            for (int i = 0; i < this._dgvDisplayAllCusPO.Rows.Count - 1; i++)
            {
                this._dgvDisplayAllCusPO.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                //MessageBox.Show("i :" + (i + 1).ToString() + ", Stt_I: " + this._dgvDisplayAllCusPO.Rows[i].Cells["STT"].Value);
            }
        }


        public virtual void SortObjectByCondition(SortingMethod sortingMethod)
        {
            DataTable dt = this._dgvDisplayAllCusPO.DataSource as DataTable;
            if (dt == null) return;

            string columnSort = "";
            switch (sortingMethod)
            {
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

            this.UpdateRowNumbers();
        }
    }
}
