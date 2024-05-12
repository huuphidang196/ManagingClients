using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DTO.Customer
{
    [Serializable]
    public class DeliveryCost
    {
        public Merchandise Merchandise { get; set; }

        public int Price_To_VietNam { get; set; }

        public int Price_To_Customer{ get; set; }


    }
}
