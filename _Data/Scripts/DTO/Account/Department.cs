using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DTO.Account
{
    public class Department
    {
        public int ID_Department { get; set; }
        public string Name_Department { get; set; }

        public List<ProfileAccount> List_Staff { get; private set; }

        public virtual void AddStaffIntoDepartment(ProfileAccount profileAccount)
        {
            this.List_Staff.Add(profileAccount);
        }

        public Department(int id, string name_Department)
        {
            this.ID_Department = id;
            this.Name_Department = name_Department;
        }
    }

  
    //public enum Department
    //{
    //    NO_DEPARTMENT = 0,

    //    GSES_COMPANY = 1,

    //    TECHNICAL_DEPARTMENT = 2,

    //    SALE_DEPARTMENT = 3,

    //    ACCOUNTING_DEPARTMENT = 4,

    //}
}
