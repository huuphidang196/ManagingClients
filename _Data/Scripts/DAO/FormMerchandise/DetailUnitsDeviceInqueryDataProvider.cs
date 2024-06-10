using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DAO.FormMerchandise
{
    public class DetailUnitsDeviceInqueryDataProvider : DataProvider
    {
        private static DetailUnitsDeviceInqueryDataProvider _instance;
        public static DetailUnitsDeviceInqueryDataProvider Instance
        {
            get
            {
                if (_instance == null) _instance = new DetailUnitsDeviceInqueryDataProvider();
                return DetailUnitsDeviceInqueryDataProvider._instance;
            }

            private set { DetailUnitsDeviceInqueryDataProvider._instance = value; }
        }

        private DetailUnitsDeviceInqueryDataProvider()
        {

        }
        #region Query
        protected virtual List<UnitsDeviceInquery> GetListUnitsDeviceInqueryByQuery(string query)
        {
            List<UnitsDeviceInquery> listUnitsDeviceInquery = new List<UnitsDeviceInquery>();

            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, null);

            while (reader.Read())
            {
                UnitsDeviceInquery unitsDeviceInquery = new UnitsDeviceInquery();

                unitsDeviceInquery.ID_Units_Device_Inquery = reader.GetInt32(0);

                unitsDeviceInquery.Name_Units_Device_Inquery = reader.GetString(1);

                unitsDeviceInquery.Count_Set_Units_Device_Inquery = reader.GetInt32(2);

                unitsDeviceInquery.Percent_VAT_Units_Device_Inquery = reader.GetDecimal(3);

                unitsDeviceInquery.Cost_Delivery_To_VN = reader.GetDecimal(4);

                unitsDeviceInquery.Cost_Delivery_To_Customer = reader.GetDecimal(5);

                unitsDeviceInquery.Percent_Benefit_Cost_Delivery_To_Cus = reader.GetDecimal(6);

                unitsDeviceInquery.Percent_Benefit_Cost_Units_Inquery = reader.GetDecimal(7);

                unitsDeviceInquery.Final_Value_Units_Device_Inquery = reader.GetDecimal(8);

                unitsDeviceInquery.ID_Inquery_Quotation = reader.GetInt32(9);
                
                listUnitsDeviceInquery.Add(unitsDeviceInquery);

            }

            reader.Close();

            this._Connection.Close();

            return listUnitsDeviceInquery;
        }

        public virtual List<UnitsDeviceInquery> GetListUnitsDeviceInqueryByIDInqueryQuotation(int iD_Inquery_Quotation)
        {
            string query = "Select * from UnitsDeviceInquery where ID_Inquery_Quotation=" + iD_Inquery_Quotation;

            return this.GetListUnitsDeviceInqueryByQuery(query);

        }
        protected virtual UnitsDeviceInquery GetUnitsDeviceInqueryByQuery(string query)
        {
            UnitsDeviceInquery unitsDeviceInquery = new UnitsDeviceInquery();

            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, null);

            if (reader.Read())
            {
                unitsDeviceInquery.ID_Units_Device_Inquery = reader.GetInt32(0);

                unitsDeviceInquery.Name_Units_Device_Inquery = reader.GetString(1);

                unitsDeviceInquery.Count_Set_Units_Device_Inquery = reader.GetInt32(2);

                unitsDeviceInquery.Percent_VAT_Units_Device_Inquery = reader.GetDecimal(3);

                unitsDeviceInquery.Cost_Delivery_To_VN = reader.GetDecimal(4);

                unitsDeviceInquery.Cost_Delivery_To_Customer = reader.GetDecimal(5);

                unitsDeviceInquery.Percent_Benefit_Cost_Delivery_To_Cus = reader.GetDecimal(6);

                unitsDeviceInquery.Percent_Benefit_Cost_Units_Inquery = reader.GetDecimal(7);

                unitsDeviceInquery.Final_Value_Units_Device_Inquery = reader.GetDecimal(8);

                unitsDeviceInquery.ID_Inquery_Quotation = reader.GetInt32(9);
            }

            return unitsDeviceInquery;
        }

        public virtual UnitsDeviceInquery GetUnitsDeviceInqueryByIDUnitsDevice(int id_Units_Device)
        {
            string query = "Select * from UnitsDeviceInquery where ID_Units_Device_Inquery=" + id_Units_Device;

            UnitsDeviceInquery unitsDeviceInquery = this.GetUnitsDeviceInqueryByQuery(query);

            return unitsDeviceInquery;
        }

        public virtual int GetMaxIDUnitsDeviceInquery()
        {
            string query = "SELECT TOP 1 * FROM UnitsDeviceInquery ORDER BY ID_Units_Device_Inquery DESC";
            UnitsDeviceInquery unitsDeviceInquery = this.GetUnitsDeviceInqueryByQuery(query);

            return unitsDeviceInquery.ID_Units_Device_Inquery;
        }

        #endregion

        #region Insert
        public virtual bool InsertUnitsDeviceInquery(UnitsDeviceInquery unitsDeviceInquery)
        {
            //Check to clarify that is existed customerOrder
            UnitsDeviceInquery new_UnitsDeviceInquery = this.GetUnitsDeviceInqueryByIDUnitsDevice(unitsDeviceInquery.ID_Units_Device_Inquery);

            bool value_Existed = new_UnitsDeviceInquery.ID_Units_Device_Inquery > 0;
            //if existed true => Update. false => insert 

            if (value_Existed) return this.UpdateUnitsDeviceInquery(unitsDeviceInquery);

            unitsDeviceInquery.ID_Units_Device_Inquery = this.GetMaxIDUnitsDeviceInquery() + 1;

            return this.InsertTableByNameTable(nameof(UnitsDeviceInquery), unitsDeviceInquery);

        }
        #endregion

        #region Update
        public virtual bool UpdateUnitsDeviceInquery(UnitsDeviceInquery unitsDeviceInquery)
        {
            string nameKeyColumn = "ID_Units_Device_Inquery";
            return this.UpdateDataByNameTable(nameKeyColumn, nameof(UnitsDeviceInquery), unitsDeviceInquery);
        }
        #endregion
    }
}
