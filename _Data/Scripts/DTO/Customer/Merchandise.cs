using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DTO.Customer
{
    [Serializable]
    public class ElementUnits
    {
        public string Serial_Number_Element { get; set; }//must be existed

        public string Name_Element { get; set; }//Can null
        public float Origin_Price { get; set; }//must be existed

        //Need a property specification
        public UnitsDevice UnitsDevice { get; set; }
    }

    [Serializable]
    public class UnitsDevice
    {
        public int ID_UnitsDevice { get; set; }

        public string Type_UnitsDevice { get; set; }
        public string Name_UnitsDevice { get; set; }
        public Merchandise Merchandise { get; set; }

        public List<ElementUnits> List_Elements_Units { get; private set; }

        public virtual void AddElementsUnitsD(ElementUnits elementUnits)
        {
            this.List_Elements_Units.Add(elementUnits);
        }
    }

    [Serializable]
    public class Merchandise
    {
        public int ID_Merchandise { get; set; }

        public string Name_Merchandise { get; set; }

        public InquiryQuotation InquiryQuotation { get; set; }
        public List<UnitsDevice> List_Units_Devices { get; private set; }

        public virtual void AddUnitsDevice(UnitsDevice unitsDevice)
        {
            this.List_Units_Devices.Add(unitsDevice);
        }
    }
}
