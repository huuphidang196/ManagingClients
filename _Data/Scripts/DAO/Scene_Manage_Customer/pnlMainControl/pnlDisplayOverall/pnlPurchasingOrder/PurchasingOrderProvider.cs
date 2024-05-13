using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DAO.Scene_Manage_Customer.pnlMainControl.pnlDisplayOverall.pnlPurchasingOrder
{
    public class PurchasingOrderProvider : DataProvider
    {
        private static PurchasingOrderProvider _instance;
        public static PurchasingOrderProvider Instance
        {
            get
            {
                if (_instance == null) _instance = new PurchasingOrderProvider();
                return PurchasingOrderProvider._instance;
            }

            private set { PurchasingOrderProvider._instance = value; }
        }

        #region Query
        public virtual DataTable GetDataTableAllCustomer()
        {
            string nameTable = "CustomerGSES";

            DataTable dataTable = this.GetDataTableByNameTable(nameTable);

            this._Connection.Close();

            return dataTable;
        }
       
        #endregion
    }
}
