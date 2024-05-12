using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DTO.Customer
{
    [Serializable]
    public class InformationCustomer
    {
        public string Name_Customer { get; set; }
        public string Adrress_Company { get; set; }
        public string Adress_Email { get; set;}
        public string Phone_Number { get; set; }
        public string Tax_Number { get; set; }
    }
}
