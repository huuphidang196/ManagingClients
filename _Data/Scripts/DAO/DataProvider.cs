﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ManagingClients._Data.Scripts.DAO
{
    public class DataProvider
    {
        protected string _ConnectionSTR = "Server=DANGHUUPHI\\SQLEXPRESS;Database=CSDL_GSESMC;User Id=huuphidang196;pwd=19062001Phi@";
        protected SqlConnection _Connection;

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

        #region Insert
        //Insert
        protected virtual int GetCountDataResultInsertByQueryAndParameter(string query, object[] parameter = null)
        {
            this._Connection = new SqlConnection(this._ConnectionSTR);

            if (this._Connection.State == System.Data.ConnectionState.Closed) _Connection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, this._Connection);

            if (parameter != null)
            {
                string listPara = query.Split(' ')[2];
                string[] listValue = listPara.Trim('(').Trim(')').Split(',');
                int i = 0;
                foreach (string item in listValue)
                {
                    if (item.Contains('@'))
                    {
                        sqlCommand.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }

            int ret = sqlCommand.ExecuteNonQuery();

            this._Connection.Close();

            return ret;

        }

        #endregion

        #region Update
        //Update
        protected virtual int GetCountDataResultUpdateByQueryAndParameter(string query, object[] parameter = null)
        {
            this._Connection = new SqlConnection(this._ConnectionSTR);

            if (this._Connection.State == System.Data.ConnectionState.Closed) _Connection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, this._Connection);
            //"UPDATE TableName SET Column1 = @NewValue1, Column2 = @NewValue2 WHERE ConditionColumn = @ConditionValue";
            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 1;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        sqlCommand.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }

            int ret = sqlCommand.ExecuteNonQuery();

            this._Connection.Close();

            return ret;

        }

        #endregion
    }

}
