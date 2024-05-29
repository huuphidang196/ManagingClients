using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using ManagingClients._Data.Scripts.DTO.Customer;

namespace ManagingClients._Data.Scripts.DAO
{
    public class DataProvider
    {
        protected string _ConnectionSTR = "Server=DANGHUUPHI\\SQLEXPRESS;Database=CSDL_GSESMC;User Id=huuphidang196;pwd=19062001Phi@";
        protected SqlConnection _Connection;

        protected virtual int QueryScalarByQueryAndParameter(string query, object[] parameter = null)
        {
            this._Connection = new SqlConnection(this._ConnectionSTR);

            if (this._Connection.State == System.Data.ConnectionState.Closed) _Connection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, this._Connection);

            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        sqlCommand.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }

            int count = (int)sqlCommand.ExecuteScalar();

            this._Connection.Close();

            return count;

        }

        //Read
        protected virtual SqlDataReader GetDataReaderByQueryAndParameter(string query, object[] parameter = null)
        {
            this._Connection = new SqlConnection(this._ConnectionSTR);

            if (this._Connection.State == System.Data.ConnectionState.Closed) _Connection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, this._Connection);

            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        sqlCommand.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }

            SqlDataReader reader = sqlCommand.ExecuteReader();

            return reader;

        }

        protected virtual DataTable GetDataTableByNameTable(string nameTable)
        {
            string query = "Select * from " + nameTable;

            DataTable dataTable = this.GetDataTableByExecuteQueryAndParameter(query, null);

            return dataTable;
        }
        protected virtual DataTable GetDataTableByExecuteQueryAndParameter(string query, object[] parameter = null)
        {
            DataTable dataTable = new DataTable();

            this._Connection = new SqlConnection(this._ConnectionSTR);

            if (this._Connection.State == System.Data.ConnectionState.Closed) _Connection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, this._Connection);

            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        sqlCommand.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            return dataTable;

        }

        #region Insert
        //Insert
        protected virtual bool InsertTableByNameTable(string nameTable, object valuePara)
        {
            //Check to clarify that is existed customerOrder

            string query = "Insert into " + nameTable + "(";
            Type type = null;
            // Tìm trong tất cả các assembly đã load
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = assembly.GetTypes().FirstOrDefault(t => t.Name == nameTable);
                if (type != null)
                {
                    break;
                }
            }

            int count_Value = type.GetProperties().Length;

            string queryColumn = "";
            string queryValuesColumn = "";
            object[] parameters = new object[count_Value];

            // Lặp qua các thuộc tính của class ProfileAccount
            for (int i = 0; i < count_Value; i++)
            {
                PropertyInfo property = type.GetProperties()[i];

                // Tách tên thuộc tính và chỉ lấy phần cuối cùng
                string[] parts = property.Name.Split('.');
                string propertyName = parts[parts.Length - 1];

                queryColumn += (propertyName + ",");
                queryValuesColumn += (i == count_Value - 1) ? " @" + propertyName : " @" + propertyName + " ,";
                parameters[i] = property.GetValue(valuePara);

            }

            query += (queryColumn.Trim(',') + ") Values ( " + queryValuesColumn + " )");

            int result = this.InsertExcuteNonQueryGetCountDataResultByQueryAndParameter(query, parameters);

            return result > 0;

        }

        protected virtual int InsertExcuteNonQueryGetCountDataResultByQueryAndParameter(string query, object[] parameter = null)
        {
            int posStart = 0;

            return this.ExcuteNonQueryByQueryAndParameter(posStart, query, parameter);

        }

        #endregion

        #region Update
        //Update
        protected virtual bool UpdateDataByNameTable(string nameKeyColumn, string nameTable, object valuePara)
        {
            string query = "UPDATE " + nameTable + " SET ";

            Type type = null;
            // Tìm trong tất cả các assembly đã load
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = assembly.GetTypes().FirstOrDefault(t => t.Name == nameTable);
                if (type != null)
                {
                    break;
                }
            }

            int count_Value = type.GetProperties().Length;

            string queryColumnValue = "";
            object[] parameters = new object[count_Value + 1];

            // Lặp qua các thuộc tính của class ProfileAccount
            for (int i = 0; i < count_Value; i++)
            {
                PropertyInfo property = type.GetProperties()[i];

                // Tách tên thuộc tính và chỉ lấy phần cuối cùng
                string[] parts = property.Name.Split('.');
                string propertyName = parts[parts.Length - 1];

                if (propertyName == nameKeyColumn) continue;

                queryColumnValue += (propertyName + " = " + " @" + propertyName);
                if (i != count_Value - 1) queryColumnValue += " , ";
                parameters[i] = property.GetValue(valuePara);

            }
            object valueCoulumn = type.GetProperty(nameKeyColumn).GetValue(valuePara);


            query += (queryColumnValue + " WHERE " + nameKeyColumn + " = " + " @" + nameKeyColumn);
            parameters[count_Value] = valueCoulumn;

            int result = this.UpdateExecuteNonQueryGetCountDataResultByQueryAndParameter(query, parameters);

            return result > 0;
        }
        protected virtual int UpdateExecuteNonQueryGetCountDataResultByQueryAndParameter(string query, object[] parameter = null)
        {
            int posStart = 1;

            return this.ExcuteNonQueryByQueryAndParameter(posStart, query, parameter);

        }

        #endregion

        #region Delete
        protected virtual int DeleteExcuteNonQueryGetCountDataResultByQueryAndParameter(string query, object[] parameter = null)
        {
            int posStart = 0;

            return this.ExcuteNonQueryByQueryAndParameter(posStart, query, parameter);

        }
        #endregion
        #region Excute_NonQuery

        protected virtual int ExcuteNonQueryByQueryAndParameter(int posStart, string query, object[] parameter = null)
        {
            this._Connection = new SqlConnection(this._ConnectionSTR);

            if (this._Connection.State == System.Data.ConnectionState.Closed) _Connection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, this._Connection);
            //"UPDATE TableName SET Column1 = @NewValue1, Column2 = @NewValue2 WHERE ConditionColumn = @ConditionValue";
            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = posStart;
                foreach (string item in listPara)
                {
                    if (!item.Contains('@')) continue;

                    sqlCommand.Parameters.AddWithValue(item, parameter[i]);
                    i++;
                }
            }

            int ret = sqlCommand.ExecuteNonQuery();

            this._Connection.Close();

            return ret;
        }
        #endregion
    }

}
