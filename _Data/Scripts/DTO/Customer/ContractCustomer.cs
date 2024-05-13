using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DTO.Customer
{
    public class ContractCustomer
    {
        public int ID_Contract_Customer { get; set; }

        public string Number_Contract { get; set; }//Số báo giá , mục V/v
        //a file pdf
        public DateTime Signed_Time { get; set; }
       
        public int ID_Customer_Order { get; set; } //public Customer_Order Customer_Order { get; set; }
    }
}
