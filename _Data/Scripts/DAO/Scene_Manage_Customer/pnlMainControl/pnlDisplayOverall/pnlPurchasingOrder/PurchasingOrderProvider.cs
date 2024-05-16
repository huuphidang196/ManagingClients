using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        #region Query
        public virtual CustomerGSES GetCustomerGSES(int id_CustomerGSES)
        {
            CustomerGSES customerGSES = null;

            string query = "Select * from CustomerGSES where ID_Customer=" + id_CustomerGSES;

            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, null);

            if (reader.Read())
            {
                customerGSES = new CustomerGSES();

                customerGSES.ID_Customer = reader.GetInt32(0);

                customerGSES.Name_Customer = reader.GetString(1);

                customerGSES.Address_Company = reader.GetString(2);

                customerGSES.Address_Email = reader.GetString(3);

                customerGSES.Phone_Number = reader.GetString(4);

                customerGSES.Tax_Number = reader.GetString(5);
            }

            reader.Close();

            this._Connection.Close();

            return customerGSES;
        }
        #endregion
        #endregion
    }
}
