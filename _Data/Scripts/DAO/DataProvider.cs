using System;
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
        protected string _ConnectionSTR = "Server=DANGHUUPHI/MSSQLSERVER01;Database=CSDL_MCGSES;User Id=huuphidang2804;pwd=19062001Phi@";

        protected virtual SqlDataReader GetDataReaderByQueryAndParameter(string query, object[] parameter = null)
        {
            using (SqlConnection conn = new SqlConnection(this._ConnectionSTR))
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                SqlCommand sqlCommand = new SqlCommand(query, conn);

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
        }
    }

}
