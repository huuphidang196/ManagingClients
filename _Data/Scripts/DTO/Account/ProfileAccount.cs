using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DTO.Account
{
    [Serializable]
    public class ProfileAccount
    {
        public string Name_Log_In { get; set; }
        public string Password { get; set; }
        public string Name_Realistic { get; set; }
        public Sex Sex_Account { get; set; }
        public string Email_Account { get; set; }
        
        public DateTime Date_Of_Birth { get; set; }

        public Department Department { get; set; }

        public Position Person_Position { get; set; }
        public LevelAccess Level_Access { get; set; }
        
    }
}
