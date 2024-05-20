using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer;
using ManagingClients._Data.Scripts.DAO.Scene_Manage_Customer.pnlMainControl.pnlDisplayOverall.pnlPurchasingOrder;
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

        protected virtual CustomerGSES GetCustomerGSESByIDCustomer(int id_Customer)
        {
            CustomerGSES customerGSES = PurchasingOrderProvider.Instance.GetCustomerGSES(id_Customer);

            if (customerGSES == null) return new CustomerGSES();

            return customerGSES;
        }

        //InqueryQuotation

        public virtual InqueryQuotation GetInqueryQuotationrOrderOfCustomerByIDInqueryQuotation(int id_Inquery_Quotation)
        {
            string query = "Select * from InqueryQuotation where ID_Inquery_Quotation=" + id_Inquery_Quotation;

            List<InqueryQuotation> listInqueryCustomer_Order = this.GetListInqueryCustomerOrderOfCustomerByQuery(query);

            if (listInqueryCustomer_Order.Count == 0) return new InqueryQuotation();

            return listInqueryCustomer_Order[0];
        }
        public virtual InqueryQuotation GetInqueryQuotationrOrderOfCustomerByIDCustomerOrder(int id_Customer_Order)
        {
            string query = "Select * from InqueryQuotation where ID_Customer_Order=" + id_Customer_Order;

            List<InqueryQuotation> listInqueryCustomer_Order = this.GetListInqueryCustomerOrderOfCustomerByQuery(query);

            if (listInqueryCustomer_Order.Count == 0) return new InqueryQuotation();

            return listInqueryCustomer_Order[0];
        }

        public virtual List<InqueryQuotation> GetListInqueryCustomerOrderOfCustomerByQuery(string query)
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

                Inquery_CustomerOrder.DeliveryCost_To_VietNam = (decimal)reader.GetDecimal(4);

                Inquery_CustomerOrder.DeliveryCost_To_Customer = (decimal)reader.GetDecimal(5);

                Inquery_CustomerOrder.Min_Time_Delivery = reader.GetInt32(6);

                Inquery_CustomerOrder.Max_Time_Delivery = reader.GetInt32(7);

                Inquery_CustomerOrder.Expired_Time_Inquiry = reader.GetDateTime(8);

                Inquery_CustomerOrder.Selected_Exchange_Rate = (decimal)reader.GetDecimal(9);

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
        public virtual int GetMaxIDInqueryQuotation()
        {
            InqueryQuotation inqueryQutation = new InqueryQuotation();
            string query = "SELECT TOP 1 * FROM InqueryQuotation ORDER BY ID_Inquery_Quotation DESC";
            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, null);

            if (reader.Read())
            {
                inqueryQutation.ID_Inquery_Quotation = reader.GetInt32(0);

                inqueryQutation.Name_Inquiry_Quotation = reader.GetString(1);

                inqueryQutation.Number_Inquiry_Quotation = reader.GetString(2);

                inqueryQutation.Date_Sending = reader.GetDateTime(3);

                inqueryQutation.DeliveryCost_To_VietNam = (decimal)reader.GetDecimal(4);

                inqueryQutation.DeliveryCost_To_Customer = (decimal)reader.GetDecimal(5);

                inqueryQutation.Min_Time_Delivery = reader.GetInt32(6);

                inqueryQutation.Max_Time_Delivery = reader.GetInt32(7);

                inqueryQutation.Expired_Time_Inquiry = reader.GetDateTime(8);

                inqueryQutation.Selected_Exchange_Rate = (decimal)reader.GetDecimal(9);

                if (!reader.IsDBNull(reader.GetOrdinal("File_Data_Inquiry_Quotation"))) inqueryQutation.File_Data_Inquiry_Quotation = (byte[])reader["File_Data_Inquiry_Quotation"];

                inqueryQutation.Purpose_Purchasing = reader.GetString(11);

                inqueryQutation.Name_Of_EndUser = reader.GetString(12);

                inqueryQutation.ID_Customer_Order = reader.GetInt32(13);
            }

            return inqueryQutation.ID_Inquery_Quotation;
        }
        public virtual int GetMaxIDCustomerGSES()
        {
            CustomerGSES customerGSES = new CustomerGSES();
            string query = "SELECT TOP 1 * FROM CustomerGSES ORDER BY ID_Customer DESC";
            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, null);

            if (reader.Read())
            {
                customerGSES.ID_Customer = reader.GetInt32(0);

                customerGSES.Name_Customer = reader.GetString(1);

                customerGSES.Address_Company = reader.GetString(2);

                customerGSES.Address_Email = reader.GetString(3);

                customerGSES.Phone_Number = reader.GetString(4);

                customerGSES.Tax_Number = reader.GetString(5);
            }

            return customerGSES.ID_Customer;
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

                contract_CustomerOrder.Total_Contract_Value = (decimal)reader.GetDecimal(4);

                if (!reader.IsDBNull(reader.GetOrdinal("File_Data_Contract"))) contract_CustomerOrder.File_Data_Contract = (byte[])reader["File_Data_Contract"];

                contract_CustomerOrder.ID_Customer_Order = reader.GetInt32(6);

                listContractCustomer_Order.Add(contract_CustomerOrder);
            }

            reader.Close();

            this._Connection.Close();

            return listContractCustomer_Order;
        }
        public virtual int GetMaxIDContractCustomer()
        {
            ContractCustomer contractCustomer = new ContractCustomer();
            string query = "SELECT TOP 1 * FROM ContractCustomer ORDER BY ID_Contract_Customer DESC";
            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, null);

            if (reader.Read())
            {
                contractCustomer.ID_Contract_Customer = reader.GetInt32(0);

                contractCustomer.Number_Contract = reader.GetString(1);

                contractCustomer.Signed_Time = reader.GetDateTime(2);

                contractCustomer.Expired_Time = reader.GetDateTime(3);

                contractCustomer.Total_Contract_Value = (decimal)reader.GetDecimal(4);

                if (!reader.IsDBNull(reader.GetOrdinal("File_Data_Contract"))) contractCustomer.File_Data_Contract = (byte[])reader["File_Data_Contract"];

                contractCustomer.ID_Customer_Order = reader.GetInt32(6);
            }

            return contractCustomer.ID_Contract_Customer;
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

        public virtual int GetMaxIDCustomerOrder()
        {
            CustomerOrder customerOrder = new CustomerOrder();
            string query = "SELECT TOP 1 * FROM CustomerOrder ORDER BY ID_Customer_Order DESC";
            SqlDataReader reader = this.GetDataReaderByQueryAndParameter(query, null);

            if (reader.Read())
            {          
                customerOrder.ID_Customer_Order = reader.GetInt32(0);

                customerOrder.Name_Order = reader.GetString(1);

                customerOrder.Status_Order = (StatusOrder)Enum.Parse(typeof(StatusOrder), reader.GetString(2), true);

                customerOrder.Name_Log_In = reader.GetString(3);

                customerOrder.Level_Pos_Access_Order = (Position)Enum.Parse(typeof(Position), reader.GetString(4), true);

                customerOrder.Level_Access_Order = (LevelAccess)Enum.Parse(typeof(LevelAccess), reader.GetString(5), true);

                customerOrder.ID_Customer = reader.GetInt32(6);
            }

            return customerOrder.ID_Customer_Order;
        }
        #endregion Query

        #region Insert
        public virtual bool InsertCustomerOrder(CustomerOrder customerOrder)
        {
            //Check to clarify that is existed customerOrder
            CustomerOrder new_customer_Order = this.GetCustomerOrderOfCustomerByIDCustomerOrder(customerOrder.ID_Customer_Order);

            bool value_Existed = new_customer_Order.ID_Customer_Order > 0;
            //if existed true => Update. false => insert 

            if (value_Existed) return this.UpdateCustomerOrder(customerOrder);

            customerOrder.ID_Customer_Order = this.GetMaxIDCustomerOrder() + 1;

            return this.InsertTableByNameTable(nameof(CustomerOrder), customerOrder);

        }

        public virtual bool InsertInqueryQuotation(InqueryQuotation inqueryQuatation)
        {
            //Check to clarify that is existed customerOrder
            //Find by ID_Customer_Order beacause ID_Inquery_Quotation havenot been set
            InqueryQuotation new_inqueryQuatation = this.GetInqueryQuotationrOrderOfCustomerByIDCustomerOrder(inqueryQuatation.ID_Customer_Order);

            bool value_Existed = new_inqueryQuatation.ID_Inquery_Quotation > 0;
            //if existed true => Update. false => insert 

            if (value_Existed) return this.UpdateInqueryQuotation(inqueryQuatation);

            inqueryQuatation.ID_Inquery_Quotation = this.GetMaxIDInqueryQuotation() + 1;

            return this.InsertTableByNameTable(nameof(InqueryQuotation), inqueryQuatation);

        }

        public virtual bool InsertCustomerContract(ContractCustomer contractCustomer)
        {
            //Check to clarify that is existed customerOrder
            //Find by ID_Customer_Order beacause ID_Inquery_Quotation havenot been set
            ContractCustomer new_contractCustomer = this.GetContractQuotationrOrderOfCustomerByIDCustomerOrder(contractCustomer.ID_Customer_Order);

            bool value_Existed = new_contractCustomer.ID_Contract_Customer > 0;
            //if existed true => Update. false => insert 

            if (value_Existed) return this.UpdateContractCustomer(contractCustomer);

            contractCustomer.ID_Contract_Customer = this.GetMaxIDContractCustomer() + 1;

            return this.InsertTableByNameTable(nameof(ContractCustomer), contractCustomer);

        }

        public virtual bool InsertCustomerGSES(CustomerGSES customerGSES)
        {
            //Check to clarify that is existed customerOrder
            //Find by ID_Customer_Order beacause ID_Inquery_Quotation havenot been set
            CustomerGSES new_CustomerGSES = this.GetCustomerGSESByIDCustomer(customerGSES.ID_Customer);

            bool value_Existed = new_CustomerGSES.ID_Customer > 0;
            //if existed true => Update. false => insert 

            if (value_Existed) return this.UpdateCustomerGSES(customerGSES);

            customerGSES.ID_Customer = this.GetMaxIDCustomerGSES() + 1;

            return this.InsertTableByNameTable(nameof(CustomerGSES), customerGSES);

        }
        #endregion Insert

        #region Update
        public virtual bool UpdateCustomerOrder(CustomerOrder customerOrder)
        {
            string nameKeyColumn = "ID_Customer_Order";
            return this.UpdateDataByNameTable(nameKeyColumn, nameof(CustomerOrder), customerOrder);
        }

        public virtual bool UpdateInqueryQuotation(InqueryQuotation inqueryQuatation)
        {
            string nameKeyColumn = "ID_Inquery_Quotation";
            return this.UpdateDataByNameTable(nameKeyColumn, nameof(InqueryQuotation), inqueryQuatation);
        }
        public virtual bool UpdateContractCustomer(ContractCustomer customerContract)
        {
            string nameKeyColumn = "ID_Contract_Customer";
            return this.UpdateDataByNameTable(nameKeyColumn, nameof(ContractCustomer), customerContract);
        }
        public virtual bool UpdateCustomerGSES(CustomerGSES customerGSES)
        {
            string nameKeyColumn = "ID_Customer";
            return this.UpdateDataByNameTable(nameKeyColumn, nameof(CustomerGSES), customerGSES);
        }
        #endregion

        #region Delete
        //CustomerOrder
        public virtual bool DeleteCustomerOrderByID(int id_Customer_Order)
        {
            string query = "DELETE FROM CustomerOrder WHERE ID_Customer_Order =" + id_Customer_Order;

            return this.DeleteExcuteNonQueryGetCountDataResultByQueryAndParameter(query, null) > 0;

        }
        
        //Inquery
        public virtual bool DeleteInqueryByIDCustomerOrder(int id_CustomerOrder)
        {
            string query = "DELETE FROM InqueryQuotation WHERE ID_Customer_Order =" + id_CustomerOrder;

            return this.DeleteExcuteNonQueryGetCountDataResultByQueryAndParameter(query, null) > 0;

        }

        //Contract
        public virtual bool DeleteContractByIDCustomerOrder(int id_CustomerOrder)
        {
            string query = "DELETE FROM ContractCustomer WHERE ID_Customer_Order =" + id_CustomerOrder;

            return this.DeleteExcuteNonQueryGetCountDataResultByQueryAndParameter(query, null) > 0;

        }
        #endregion
    }
}
