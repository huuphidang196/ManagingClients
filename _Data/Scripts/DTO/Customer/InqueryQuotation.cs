﻿using System;
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
    
        public int DeliveryCost_To_VietNam { get; set; }

        public int DeliveryCost_To_Customer { get; set; }        //public DeliveryCost DeliveryCost { get; set; }

        public float Min_Time_Delivery { get; set; }        //public RangeValue Time_Delivery { get; set; }


        public float Max_Time_Delivery { get; set; }
        
        public DateTime Expired_Time_Inquiry { get; set; }

        public float Benefit_Percent { get; set; }//Phần trăm

        public byte[] File_Data_Inquiry_Quotation { get; set; }

        public int ID_Customer_Order { get; set; }   //  public Customer_Order Customer_Order { get; set; }

        public List<Merchandise> List_Merchandise_IntoInquery { get; private set; }

        public virtual void AddMerchandise(Merchandise merchandise)
        {
            this.List_Merchandise_IntoInquery.Add(merchandise);
        }
        public virtual void RemoveMerchandise(Merchandise merchandise)
        {
            this.List_Merchandise_IntoInquery.Remove(merchandise);
        }
    }
}