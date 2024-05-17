using ManagingClients._Data.Scripts.DTO.Account;
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

        Wait_Pay_Complete = 4,

        Delivering = 5,

        Arriving_Customer = 6,

        Finished_Contract = 7
    }

    public class CustomerOrder
    {
        public int ID_Customer_Order { get; set; }

        public string Name_Order { get; set; }

        public StatusOrder Status_Order { get; set; }

        public string Name_Log_In { get; set; }//ID người tạo// nameLogin Person generated
        public Position Level_Pos_Access_Order { get; set; }
        public LevelAccess Level_Access_Order { get; set; }

        public int ID_Customer { get; set; }            //public Customer Customer { get; set; }


        //List Inquery
        public List<InqueryQuotation> List_Inquery_Quatations { get; private set; }

        public virtual void AddUnitsDeviceInquery(InqueryQuotation inqueryQuotation)
        {
            this.List_Inquery_Quatations.Add(inqueryQuotation);
        }
        public virtual void RemoveUnitsDeviceInquery(InqueryQuotation inqueryQuotation)
        {
            this.List_Inquery_Quatations.Remove(inqueryQuotation);
        }

        //List contract
        public List<ContractCustomer> List_Contracts_Customer { get; private set; }

        public virtual void AddContractCustomer(ContractCustomer contractCustomer)
        {
            this.List_Contracts_Customer.Add(contractCustomer);
        }
        public virtual void RemoveContractCustomer(ContractCustomer contractCustomer)
        {
            this.List_Contracts_Customer.Remove(contractCustomer);
        }



    }

    public class CustomerGSES
    {
        public int ID_Customer { get; set; }

        public string Name_Customer { get; set; }

        public string Address_Company { get; set; }

        public string Address_Email { get; set; }

        public string Phone_Number { get; set; }

        public string Tax_Number { get; set; }

        //public Customer_Order Customer_Order { get; set; }

        public List<CustomerOrder> List_Customer_Order { get; private set; }

        public virtual void AddCustomerOrder(CustomerOrder customer_Order)
        {
            this.List_Customer_Order.Add(customer_Order);
        }
        public virtual void RemoveCustomerOrder(CustomerOrder customer_Order)
        {
            this.List_Customer_Order.Remove(customer_Order);
        }
    }
}
