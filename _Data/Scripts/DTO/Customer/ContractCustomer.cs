using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DTO.Customer
{
    public class ContractCustomer
    {
        //a file pdf
        public DateTime Signed_Time { get; set; }
        public Customer_Order Customer_Order { get; set; }
    }
}
