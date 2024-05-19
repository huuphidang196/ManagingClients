﻿using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DAO.FormDetailCustomerIC
{
    public class CustomerOrderDataProvider : DataProvider
    {
        private static CustomerOrderDataProvider _instance;
        public static CustomerOrderDataProvider Instance
        {
            get
            {
                if (_instance == null) _instance = new CustomerOrderDataProvider();
                return CustomerOrderDataProvider._instance;
            }

            private set { CustomerOrderDataProvider._instance = value; }
        }

        private CustomerOrderDataProvider()
        {

        }

        #region Query

        //InqueryQuotation
        public virtual InqueryQuotation GetInqueryQuotationrOrderOfCustomerByIDCustomerOrder(int id_Customer_Order)
        {
            string query = "Select * from InqueryQuotation where ID_Customer_Order=" + id_Customer_Order;

            List<InqueryQuotation> listInqueryCustomer_Order = this.GetListInqueryCustomerOrderOfCustomerByIDCustomer(query);

            if (listInqueryCustomer_Order.Count == 0) return new InqueryQuotation();

            return listInqueryCustomer_Order[0];
        }

        public virtual List<InqueryQuotation> GetListInqueryCustomerOrderOfCustomerByIDCustomer(string query)
        {
            List<InqueryQuotation> listInqueryCustomer_Order = new List<InqueryQuotation>();

            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, null);

            while (reader.Read())
            {
                InqueryQuotation Inquery_CustomerOrder = new InqueryQuotation();

                Inquery_CustomerOrder.ID_Inquery_Quotation = reader.GetInt32(0);

                Inquery_CustomerOrder.Name_Inquiry_Quotation = reader.GetString(1);

                Inquery_CustomerOrder.Number_Inquiry_Quotation = reader.GetString(2);

                Inquery_CustomerOrder.Date_Sending = reader.GetDateTime(3);

                Inquery_CustomerOrder.DeliveryCost_To_VietNam = (float)reader.GetDecimal(4);

                Inquery_CustomerOrder.DeliveryCost_To_Customer = (float)reader.GetDecimal(5);

                Inquery_CustomerOrder.Min_Time_Delivery = reader.GetInt32(6);

                Inquery_CustomerOrder.Max_Time_Delivery = reader.GetInt32(7);

                Inquery_CustomerOrder.Expired_Time_Inquiry = reader.GetDateTime(8);

                Inquery_CustomerOrder.Selected_Exchange_Rate = (float)reader.GetDecimal(9);

                if (!reader.IsDBNull(reader.GetOrdinal("File_Data_Inquiry_Quotation"))) Inquery_CustomerOrder.File_Data_Inquiry_Quotation = (byte[])reader["File_Data_Inquiry_Quotation"];

                Inquery_CustomerOrder.Purpose_Purchasing = reader.GetString(11);

                Inquery_CustomerOrder.Name_Of_EndUser = reader.GetString(12);

                Inquery_CustomerOrder.ID_Customer_Order = reader.GetInt32(13);

                listInqueryCustomer_Order.Add(Inquery_CustomerOrder);
            }

            reader.Close();

            this._Connection.Close();

            return listInqueryCustomer_Order;
        }

        //Contract Quotation
        public virtual ContractCustomer GetContractQuotationrOrderOfCustomerByIDCustomerOrder(int id_Customer_Order)
        {
            string query = "Select * from ContractCustomer where ID_Customer_Order=" + id_Customer_Order;

            List<ContractCustomer> listInqueryCustomer_Order = this.GetListContractCustomerOrderOfCustomerByIDCustomer(query);

            if (listInqueryCustomer_Order.Count == 0) return new ContractCustomer();

            return listInqueryCustomer_Order[0];
        }

        public virtual List<ContractCustomer> GetListContractCustomerOrderOfCustomerByIDCustomer(string query)
        {
            List<ContractCustomer> listContractCustomer_Order = new List<ContractCustomer>();

            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, null);

            while (reader.Read())
            {
                ContractCustomer contract_CustomerOrder = new ContractCustomer();

                contract_CustomerOrder.ID_Contract_Customer = reader.GetInt32(0);

                contract_CustomerOrder.Number_Contract = reader.GetString(1);

                contract_CustomerOrder.Signed_Time = reader.GetDateTime(2);

                contract_CustomerOrder.Expired_Time = reader.GetDateTime(3);

                contract_CustomerOrder.Total_Contract_Value = (float)reader.GetDecimal(4);

                if (!reader.IsDBNull(reader.GetOrdinal("File_Data_Contract"))) contract_CustomerOrder.File_Data_Contract = (byte[])reader["File_Data_Contract"];

                contract_CustomerOrder.ID_Customer_Order = reader.GetInt32(6);

                listContractCustomer_Order.Add(contract_CustomerOrder);
            }

            reader.Close();

            this._Connection.Close();

            return listContractCustomer_Order;
        }

        //CustomerOrder
        public virtual CustomerOrder GetCustomerOrderOfCustomerByIDCustomerOrder(int id_Customer_Order)
        {
            string query = "Select * from CustomerOrder where ID_Customer_Order=" + id_Customer_Order;

            List<CustomerOrder> listCustomer_Order = this.GetListCustomerOrderOfCustomerByQuery(query);


            if (listCustomer_Order.Count == 0) return new CustomerOrder();

            return listCustomer_Order[0];
        }

        public virtual List<CustomerOrder> GetListCustomerOrderOfCustomerByIDCustomer(int id_Customer)
        {
            string query = "Select * from CustomerOrder where ID_Customer=" + id_Customer;

            List<CustomerOrder> listCustomer_Order = this.GetListCustomerOrderOfCustomerByQuery(query);

            return listCustomer_Order;
        }
        public virtual List<CustomerOrder> GetListCustomerOrderOfCustomerByQuery(string query)
        {
            List<CustomerOrder> listCustomer_Order = new List<CustomerOrder>();

            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, null);

            while (reader.Read())
            {
                CustomerOrder customerOrder = new CustomerOrder();

                customerOrder.ID_Customer_Order = reader.GetInt32(0);

                customerOrder.Name_Order = reader.GetString(1);

                customerOrder.Status_Order = (StatusOrder)Enum.Parse(typeof(StatusOrder), reader.GetString(2), true);

                customerOrder.Name_Log_In = reader.GetString(3);

                customerOrder.Level_Pos_Access_Order = (Position)Enum.Parse(typeof(Position), reader.GetString(4), true);

                customerOrder.Level_Access_Order = (LevelAccess)Enum.Parse(typeof(LevelAccess), reader.GetString(5), true);

                customerOrder.ID_Customer = reader.GetInt32(6);

                listCustomer_Order.Add(customerOrder);
            }

            reader.Close();

            this._Connection.Close();

            return listCustomer_Order;
        }

        public virtual int GetCountCustomerOrderByQuery()
        {
            string query = "Select count(*) from CustomerOrder";

            return this.QueryScalarByQueryAndParameter(query, null);
        }
        #endregion Query

        #region Insert
        public virtual bool InsertCustomerOrder(CustomerOrder customerOrder)
        {
            //Check to clarify that is existed customerOrder
            CustomerOrder new_customer_Order = this.GetCustomerOrderOfCustomerByIDCustomerOrder(customerOrder.ID_Customer_Order);

            bool value_Existed = new_customer_Order.ID_Customer_Order > 0;

            //Only recify id
            customerOrder.ID_Customer_Order = (value_Existed) ? customerOrder.ID_Customer_Order : this.GetCountCustomerOrderByQuery() + 1;

            string query = "Insert into CustomerOrder(";
            int count_Value = typeof(CustomerOrder).GetProperties().Length;

            string queryColumn = "";
            string queryValuesColumn = "";
            object[] parameters = new object[count_Value];

            // Lặp qua các thuộc tính của class ProfileAccount
            for (int i = 0; i < count_Value; i++)
            {
                PropertyInfo property = typeof(CustomerOrder).GetProperties()[i];

                // Tách tên thuộc tính và chỉ lấy phần cuối cùng
                string[] parts = property.Name.Split('.');
                string propertyName = parts[parts.Length - 1];

                queryColumn += (propertyName + ",");
                queryValuesColumn += (i == count_Value - 1) ? "@" + propertyName : "@" + propertyName + ",";
                parameters[i] = property.GetValue(customerOrder);

            }

            query += (queryColumn.Trim(',') + ") Values (" + queryValuesColumn + ")");

            int result = this.GetCountDataResultInsertByQueryAndParameter(query, parameters);

            return result > 0;

        }
        #endregion Insert
    }
}
