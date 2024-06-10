using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DAO.FormMerchandise
{
    public class DetailElementUnitsInqueryDataProvider : DataProvider
    {
        private static DetailElementUnitsInqueryDataProvider _instance;
        public static DetailElementUnitsInqueryDataProvider Instance
        {
            get
            {
                if (_instance == null) _instance = new DetailElementUnitsInqueryDataProvider();
                return DetailElementUnitsInqueryDataProvider._instance;
            }

            private set { DetailElementUnitsInqueryDataProvider._instance = value; }
        }

        private DetailElementUnitsInqueryDataProvider()
        {

        }

        #region Query
        protected virtual List<ElementUnitsInquery> GetListElementUnitsInqueryByQuery(string query)
        {
            List<ElementUnitsInquery> listElementUnitsInquery = new List<ElementUnitsInquery>();

            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, null);

            while (reader.Read())
            {
                ElementUnitsInquery elementUnitsInquery = new ElementUnitsInquery();

                elementUnitsInquery.ID_Element_Units_Inquery = reader.GetInt32(0);

                elementUnitsInquery.Artical_Number_Element_Inquery = reader.GetString(1);

                elementUnitsInquery.Name_Element = reader.GetString(2);

                elementUnitsInquery.Count_Element = reader.GetInt32(3);

                elementUnitsInquery.Origin_Price_MR_Per_One = reader.GetDecimal(4);

                elementUnitsInquery.Artical_Design_Element = reader.GetString(5);

                elementUnitsInquery.ID_Units_Device_Inquery = reader.GetInt32(6);
            }

            reader.Close();

            this._Connection.Close();

            return listElementUnitsInquery;
        }

        public virtual List<ElementUnitsInquery> GetListElementUnitsInqueryByIDUnitDevice(int iD_Units_Device_Inquery)
        {
            string query = "Select * from ElementUnitsInquery where ID_Units_Device_Inquery=" + iD_Units_Device_Inquery;

            return this.GetListElementUnitsInqueryByQuery(query);

        }
        protected virtual ElementUnitsInquery GetElementUnitsInqueryByQuery(string query)
        {
            ElementUnitsInquery elementUnitsInquery = new ElementUnitsInquery();

            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, null);

            if (reader.Read())
            {
                elementUnitsInquery.ID_Element_Units_Inquery = reader.GetInt32(0);

                elementUnitsInquery.Artical_Number_Element_Inquery = reader.GetString(1);

                elementUnitsInquery.Name_Element = reader.GetString(2);

                elementUnitsInquery.Count_Element = reader.GetInt32(3);

                elementUnitsInquery.Origin_Price_MR_Per_One = reader.GetDecimal(4);

                elementUnitsInquery.Artical_Design_Element = reader.GetString(5);

                elementUnitsInquery.ID_Units_Device_Inquery = reader.GetInt32(6);
            }

            return elementUnitsInquery;
        }

        public virtual ElementUnitsInquery GetElementUnitsInqueryByIDElementUnitsInquery(int iD_Element_Units_Inquery)
        {
            string query = "Select * from ElementUnitsInquery where ID_Element_Units_Inquery=" + iD_Element_Units_Inquery;

            ElementUnitsInquery elementUnitsInquery = this.GetElementUnitsInqueryByQuery(query);

            return elementUnitsInquery;
        }

        public virtual int GetMaxIDElementUnitsInquery()
        {
            string query = "SELECT TOP 1 * FROM ElementUnitsInquery ORDER BY ID_Element_Units_Inquery DESC";
            ElementUnitsInquery unitsDeviceInquery = this.GetElementUnitsInqueryByQuery(query);

            return unitsDeviceInquery.ID_Units_Device_Inquery;
        }

        #endregion

        #region Insert
        public virtual bool InsertElementUnitsInquery(ElementUnitsInquery elementUnitsInquery)
        {
            //Check to clarify that is existed customerOrder
            ElementUnitsInquery new_ElementUnitsInquery = this.GetElementUnitsInqueryByIDElementUnitsInquery(elementUnitsInquery.ID_Element_Units_Inquery);

            bool value_Existed = new_ElementUnitsInquery.ID_Element_Units_Inquery > 0;
            //if existed true => Update. false => insert 

            if (value_Existed) return this.UpdateElementUnitsInquery(elementUnitsInquery);

            elementUnitsInquery.ID_Units_Device_Inquery = this.GetMaxIDElementUnitsInquery() + 1;

            return this.InsertTableByNameTable(nameof(UnitsDeviceInquery), elementUnitsInquery);

        }
        #endregion

        #region Update
        public virtual bool UpdateElementUnitsInquery(ElementUnitsInquery elementUnitsInquery)
        {
            string nameKeyColumn = "ID_Element_Units_Inquery";
            return this.UpdateDataByNameTable(nameKeyColumn, nameof(ElementUnitsInquery), elementUnitsInquery);
        }
        #endregion
    }
}
