using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.DTO.Account
{
    public enum Department
    {
        NO_DEPARTMENT = 0,

        COMPANY = 1,
        
        TECHNICAL_DEPARTMENT = 2,
        
        SALE_DEPARTMENT = 3,
        
        ACCOUNTING_DEPARTMENT = 4,

    }
    public enum Position
    {
        VISITOR = 0,

        PRESIDENT = 1,
        
        DIRECTOR = 2,

        HEAD_OF_DEPARTMENT = 3,

        DEPUTY_OF_DEPARTMENT = 4, // PHÓ PHÒNG

        LEADER_TEAM_DEPARTMENT = 5, // TRƯỞNG NHÓM

        EMPLOYEE = 6,
    }

    public enum LevelAccess
    {
        LEVEL_ZERO = 0,//KHÁCH

        LEVEL_05 = 1, // CHỦ TỊCH, GIÁM ĐỐC

        LEVEL_04 = 2, // TRƯỞNG PHÒNG

        LEVEL_03 = 3, // PHÓ PHÒNG

        LEVEL_02 = 4, //NHÓM TRƯỞNG

        LEVEL_01 = 5, //NHÂN VIÊN
    }

    public enum Sex
    {
        MEN = 0,

        WOMAN = 1,   
    }
}
