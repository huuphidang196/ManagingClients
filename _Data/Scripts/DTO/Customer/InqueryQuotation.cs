using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DTO.Customer
{
    //[Serializable]
    //public class RangeValue
    //{
    //    public float Value_Min { get; set; }
    //    public float Value_Max { get; set; }
    //}
    [Serializable]
    public class InqueryQuotation
    {
        public int ID_Inquery_Quotation { get; set; }

        public string Name_Inquiry_Quotation { get; set; }

        public string Number_Inquiry_Quotation { get; set; }//Số báo giá , mục V/v

        public DateTime Date_Sending { get; set; }
    
        public decimal DeliveryCost_To_VietNam { get; set; }

        public decimal DeliveryCost_To_Customer { get; set; }        //public DeliveryCost DeliveryCost { get; set; }

        public int Min_Time_Delivery { get; set; }        //public RangeValue Time_Delivery { get; set; }


        public int Max_Time_Delivery { get; set; }
        
        public DateTime Expired_Time_Inquiry { get; set; }

        public decimal Selected_Exchange_Rate { get; set; }// Tỉ giá báo 

        public byte[] File_Data_Inquiry_Quotation { get; set; }

        public string Purpose_Purchasing { get; set; }
        public string Name_Of_EndUser { get; set; }
        public int ID_Customer_Order { get; set; }   //  public Customer_Order Customer_Order { get; set; }

        //public List<Merchandise> List_Merchandise_IntoInquery { get; private set; }

        //public virtual void AddMerchandise(Merchandise merchandise)
        //{
        //    this.List_Merchandise_IntoInquery.Add(merchandise);
        //}
        //public virtual void RemoveMerchandise(Merchandise merchandise)
        //{
        //    this.List_Merchandise_IntoInquery.Remove(merchandise);
        //}
    }
}
