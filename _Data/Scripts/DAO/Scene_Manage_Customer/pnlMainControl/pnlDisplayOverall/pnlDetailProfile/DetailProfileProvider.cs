using ManagingClients._Data.Scripts.DTO.Account;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DAO.Scene_Manage_Customer.pnlMainControl.pnlDisplayOverall.pnlDetailProfile
{
    public class DetailProfileProvider : DataProvider
    {
        private static DetailProfileProvider _instance;
        public static DetailProfileProvider Instance
        {
            get
            {
                if (_instance == null) _instance = new DetailProfileProvider();
                return DetailProfileProvider._instance;
            }

            private set { DetailProfileProvider._instance = value; }
        }

        public virtual ProfileAccount GetProfileAccount()
        {
            ProfileAccount profileAccount = new ProfileAccount();

            string query = "Select *from ProfileAccount Where Name_Log_In=@namelog";


            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, new object[] { "danghuuphi1906" });

            while (reader.Read())
            {
                string nmaeLog = reader.GetString(0);

                string Password = reader.GetString(1);

                string Name_Realistic = reader.GetString(2);

                //Sex Sex_Account = reader.GetString(3);

                //string Email_Account = reader.GetString(0);

                //DateTime Date_Of_Birth = reader.GetString(0);

                //Department Department = reader.GetString(0);

                //Position Person_Position = reader.GetString(0);
                //LevelAccess Level_Access = reader.GetString(0);
            }

            return profileAccount;
        }
    }
}
