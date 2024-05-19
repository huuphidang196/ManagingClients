using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer;
using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl;
using ManagingClients._Data.Scripts.DTO.Account;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

        #region Query
        public virtual ProfileAccount GetProfileAccountByNameLogIn(string nameLogin)
        {
            ProfileAccount profileAccount = null;

            string query = "Select * from ProfileAccount where Name_Log_In=N'" + nameLogin + "'";


            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, null);

            if (reader.Read())
            {
                profileAccount = new ProfileAccount();

                profileAccount.Name_Log_In = reader.GetString(0);

                profileAccount.Password = reader.GetString(1);

                profileAccount.Name_Realistic = reader.GetString(2);

                profileAccount.Sex_Account = (Sex)Enum.Parse(typeof(Sex), reader.GetString(3));

                profileAccount.Email_Account = reader.GetString(4);

                profileAccount.Address_Home = reader.GetString(5);

                profileAccount.Date_Of_Birth = reader.GetDateTime(6);

                profileAccount.Person_Position = (Position)Enum.Parse(typeof(Position), reader.GetString(7));

                profileAccount.Level_Access = (LevelAccess)Enum.Parse(typeof(LevelAccess), reader.GetString(8));

                // Đọc dữ liệu hình ảnh từ cột ImageData

                if (!reader.IsDBNull(reader.GetOrdinal("Picture_Avatar"))) profileAccount.Picture_Avatar = (byte[])reader["Picture_Avatar"];

                profileAccount.ID_Department = reader.GetInt32(10);
            }

            reader.Close();

            this._Connection.Close();

            return profileAccount;
        }
        #endregion

        #region Insert
        public virtual bool InsertDataProfileAccount(ProfileAccount profileAccount)
        {
            //Check to clarify that is existed customerOrder
            ProfileAccount new_Profile_Account = this.GetProfileAccountByNameLogIn(profileAccount.Name_Log_In);

            bool value_Existed = new_Profile_Account != null;

            //if existed true => Update. false => insert 

            if (value_Existed) return this.UpdateDataProfileAccount(profileAccount);

            return this.InsertTableByNameTable(nameof(ProfileAccount), profileAccount);
        }

        public virtual byte[] ImageToByteArray(Image image)
        {
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

            return memoryStream.ToArray();
        }
        #endregion


        #region Update

        public virtual bool UpdateDataProfileAccount(ProfileAccount profileAccount)
        {
            string nameKeyColumn = "Name_Log_In";
            return this.UpdateDataByNameTable(nameKeyColumn, nameof(ProfileAccount), profileAccount);
        }

        #endregion
        // public virtual byte[] 
        public virtual string GetNameDepartment(int ID_Department)
        {
            string query = "Select * from Department where ID_Department=" + ID_Department;

            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, null);

            string Name_Department = "GUEST";

            if (reader.Read())
            {
                Name_Department = reader.GetString(1);
            }

            reader.Close();

            this._Connection.Close();

            return Name_Department;
        }
    }
}
