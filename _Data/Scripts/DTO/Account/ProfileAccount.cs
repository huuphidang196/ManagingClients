using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public string Address_Home { get; set; }

        public DateTime Date_Of_Birth { get; set; }

        public Position Person_Position { get; set; }
      
        public LevelAccess Level_Access { get; set; }

        public byte[] Picture_Avatar { get; set; } // Thuộc tính để lưu trữ dữ liệu hình ảnh dưới dạng mảng byte

        public Department Department { get; set; }//Variable

        public virtual string  GetNamePosition()
        {
            if (this.Person_Position == Position.EMPLOYEE) return "Nhân Viên";
            else if (this.Person_Position == Position.LEADER_TEAM_DEPARTMENT) return "Trưởng Nhóm";
            else if (this.Person_Position == Position.DEPUTY_OF_DEPARTMENT) return "Phó Phòng";
            else if (this.Person_Position == Position.HEAD_OF_DEPARTMENT) return "Trưởng Phòng";
            else if (this.Person_Position == Position.DIRECTOR) return "Giám Đốc";
            else if (this.Person_Position == Position.PRESIDENT) return "Chủ Tịch";

            return "Khách";
        }

    }
}
