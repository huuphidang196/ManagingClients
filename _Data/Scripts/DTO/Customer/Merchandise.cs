using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DTO.Customer
{
    [Serializable]
    public class ElementUnitsInquery
    {
        //Need a property specification
        public string Serial_Number_Element_Inquery { get; set; }//must be existed => in quatation it's ID
        public int ID_Type_Element_Units { get; set; }
        public float Origin_Price_MR { get; set; }//must be existed
        public byte[] File_Data_Element_Units_Inquery { get; set; }//Thông số kt phía MR Gủi/ MR send
        public int ID_Units_Device_Inquery { get; set; } // public UnitsDevice UnitsDevice { get; set; }

    }

    [Serializable]
    public class UnitsDeviceInquery
    {
        public int ID_Units_Device_Inquery { get; set; }

        public int ID_Type_Units_Device { get; set; }//ID loại tb. ID_Type_units Device

        public int ID_Merchandise { get; set; } //  public Merchandise Merchandise { get; set; }

        //public List<ElementUnitsInquery> List_Elements_UnitsInquery { get; private set; }

        //public virtual void AddElementsUnitsDeviceInquery(ElementUnitsInquery elementUnitsInquery)
        //{
        //    this.List_Elements_UnitsInquery.Add(elementUnitsInquery);
        //}
        //public virtual void RemoveElementsUnitsDeviceInquery(ElementUnitsInquery elementUnitsInquery)
        //{
        //    this.List_Elements_UnitsInquery.Remove(elementUnitsInquery);
        //}
    }

    [Serializable]
    public class Merchandise
    {
        public int ID_Merchandise { get; set; }

        public string Name_Merchandise { get; set; }

        // public InquiryQuotation InquiryQuotation { get; set; }
        public int ID_Inquery_Quotation { get; set; }

        //public List<UnitsDeviceInquery> List_Units_Devices_Inquery { get; private set; }

        //public virtual void AddUnitsDeviceInquery(UnitsDeviceInquery unitsDeviceInquery)
        //{
        //    this.List_Units_Devices_Inquery.Add(unitsDeviceInquery);
        //}
        //public virtual void RemoveUnitsDeviceInquery(UnitsDeviceInquery unitsDeviceInquery)
        //{
        //    this.List_Units_Devices_Inquery.Remove(unitsDeviceInquery);
        //}
    }
}
