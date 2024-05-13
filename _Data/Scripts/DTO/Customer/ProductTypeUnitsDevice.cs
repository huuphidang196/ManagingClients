using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DTO.Customer
{
    [Serializable]
    public class ProductTypeUnitsDevice
    {
        public int ID_Type_Units_Device { get; set; }
        public string Name_Type_Units_Device { get; set; }
    }

    [Serializable]
    public class ProductTypeElements
    {
        public string ID_Type_Element_Units { get; set; }//must be existed
        public string Name_Type_Element_Units { get; set; }
        public byte[] File_Data_Doucuments_Element_Units { get; set; }

    }
}

