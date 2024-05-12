using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DTO.Customer
{
    public enum StatusOrder
    {
        Require_Inquiry = 0,

        Send_Inquiry = 1,

        Require_Contract = 2,

        Cancel_Contract = 3,

        Signed_Contract = 4,

        Wait_Pay_Complete = 5,

        Finished_Contract = 6
    }

    public class Customer_Order
    {
        public int ID_Customer_Order { get; set; }

        public InquiryQuotation InquiryQuotation { get; set; }
        public ContractCustomer ContractCustomer { get; set; }

        public StatusOrder StatusOrder { get; set; }
        public Customer Customer { get; set; }

    }

    public class Customer
    {
        public int ID_Customer { get; set; }
        public InformationCustomer InformationCustomer { get; set; }
        public Customer_Order Customer_Order { get; set; }

        public List<Customer_Order> List_Customer_Order { get; private set; }

        public virtual void AddCustomerOrder(Customer_Order customer_Order)
        {
            this.List_Customer_Order.Add(customer_Order);
        }
    }
}
