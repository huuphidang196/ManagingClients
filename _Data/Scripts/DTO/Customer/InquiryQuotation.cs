using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DTO.Customer
{
    [Serializable]
    public class RangeValue
    {
        public float Value_Min { get; set; }
        public float Value_Max { get; set; }
    }
    [Serializable]
    public class InquiryQuotation
    {
        public string Name_Inquiry_Quotation { get; set; }
        public Merchandise Merchandise { get; set; }

        public DeliveryCost DeliveryCost { get; set; }

        public RangeValue Time_Delivery { get; set; }

        public DateTime Expired_Time_Inquiry { get; set; }

        public float Benefit_Percent { get; set; }//Phần trăm

        public Customer_Order Customer_Order { get; set; }


    }
}
