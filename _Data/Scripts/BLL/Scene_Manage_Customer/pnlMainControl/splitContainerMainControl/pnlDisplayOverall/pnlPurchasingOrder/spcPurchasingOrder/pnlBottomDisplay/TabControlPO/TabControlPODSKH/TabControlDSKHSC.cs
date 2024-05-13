using ManagingClients._Data.Scripts.DAO.Scene_Manage_Customer.pnlMainControl.pnlDisplayOverall.pnlPurchasingOrder;
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
        }
        public virtual void ShowAllListCustomer()
        {
            DataTable dataTable = PurchasingOrderProvider.Instance.GetDataTableAllCustomer();

            this._dgvDisplayAllCusPO.DataSource = dataTable;

            //recify column name
            this._dgvDisplayAllCusPO.Columns["ID_Customer"].HeaderText = "STT";
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

        }
    }
}
