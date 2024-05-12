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
        public virtual ProfileAccount GetProfileAccount(string nameLogin)
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

                int ID_Department = reader.GetInt32(10);
                profileAccount.Department = new Department(ID_Department, this.GetNameDepartment(ID_Department));
            }

            reader.Close();

            this._Connection.Close();

            return profileAccount;
        }
        #endregion

        #region Insert
        public virtual bool InsertDataProfileAccount(ProfileAccount profileAccount)
        {
            string query = "Insert into ProfileAccount(";
            string queryColumn = "";
            string queryValuesColumn = "";
            int count_Value = typeof(ProfileAccount).GetProperties().Length;
            object[] parameters = new object[count_Value];

            // Lặp qua các thuộc tính của class ProfileAccount
            for (int i = 0; i < count_Value; i++)
            {
                PropertyInfo property = typeof(ProfileAccount).GetProperties()[i];

                // Tách tên thuộc tính và chỉ lấy phần cuối cùng
                string[] parts = property.Name.Split('.');
                string propertyName = parts[parts.Length - 1];

                if (propertyName == "Department")
                {
                    queryColumn += "ID_Department,";
                    queryValuesColumn += "@ID_Department";

                    parameters[i] = profileAccount.Department.ID_Department;
                    continue;
                }

                queryColumn += (propertyName + ",");
                queryValuesColumn += "@" + propertyName + ",";
                parameters[i] = property.GetValue(profileAccount);

            }

            query += (queryColumn.Trim(',') + ") Values (" + queryValuesColumn + ")");

            int result = this.GetCountDataResultInsertByQueryAndParameter(query, parameters);

            return result > 0;
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
            string query = "UPDATE ProfileAccount SET ";
            string queryColumn = "";

            int count_Value = typeof(ProfileAccount).GetProperties().Length;//Diff insert
            object[] parameters = new object[count_Value];

            // Lặp qua các thuộc tính của class ProfileAccount
            for (int i = 0; i < count_Value; i++)
            {
                PropertyInfo property = typeof(ProfileAccount).GetProperties()[i];

                // Tách tên thuộc tính và chỉ lấy phần cuối cùng
                string[] parts = property.Name.Split('.');
                string propertyName = parts[parts.Length - 1];

                if (propertyName == "Name_Log_In") continue;

                if (propertyName == "Department")
                {
                    queryColumn += " ID_Department= @ID_Department,";
                    parameters[i] = profileAccount.Department.ID_Department;
                    continue;
                }
                //"UPDATE TableName SET Column1 = @NewValue1, Column2 = @NewValue2 WHERE ConditionColumn = @ConditionValue";
                queryColumn += (propertyName + "= @" + propertyName + " , ");
                parameters[i] = property.GetValue(profileAccount);

            }

            query += (queryColumn.Trim(',') + " WHERE Name_Log_In=N'" + profileAccount.Name_Log_In + "'");

            int result = this.GetCountDataResultUpdateByQueryAndParameter(query, parameters);

            return result > 0;
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
