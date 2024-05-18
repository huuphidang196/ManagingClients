using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
        public virtual InqueryQuotation GetInqueryQuotationrOrderOfCustomerByIDCustomerOrder(int id_Customer_Order)
        {
            string query = "Select * from InqueryQuotation where ID_Customer_Order=" + id_Customer_Order;

            List<InqueryQuotation> listInqueryCustomer_Order = this.GetListInqueryCustomerOrderOfCustomerByIDCustomer(query);

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

                Inquery_CustomerOrder.DeliveryCost_To_VietNam = reader.GetFloat(4);

                Inquery_CustomerOrder.DeliveryCost_To_Customer = reader.GetFloat(5);

                Inquery_CustomerOrder.Min_Time_Delivery = reader.GetInt32(6);

                Inquery_CustomerOrder.Max_Time_Delivery = reader.GetInt32(7);

                Inquery_CustomerOrder.Expired_Time_Inquiry = reader.GetDateTime(8);

                Inquery_CustomerOrder.Selected_Exchange_Rate = reader.GetFloat(9);

                Inquery_CustomerOrder.File_Data_Inquiry_Quotation = (byte[])reader["File_Data_Inquiry_Quotation"];

                Inquery_CustomerOrder.Purpose_Purchasing = reader.GetString(11);

                Inquery_CustomerOrder.Name_Of_EndUser = reader.GetString(12);

                Inquery_CustomerOrder.ID_Customer_Order = reader.GetInt32(13);

                listInqueryCustomer_Order.Add(Inquery_CustomerOrder);
            }

            reader.Close();

            this._Connection.Close();

            return listInqueryCustomer_Order;
        }

        //CustomerOrder
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
    }
}
