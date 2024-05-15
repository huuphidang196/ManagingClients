using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer
{
    public static class TransferEnumString
    {
        public static string TransferSortingMethodToString(SortingMethod sortingMethod)
        {
            switch (sortingMethod)
            {
                case SortingMethod.Sort_A_Z:
                    return "Từ A --> Z";
                case SortingMethod.Sort_Z_A:
                    return "Từ Z --> A";
                case SortingMethod.Total_Contract:
                    return "Tổng số Hợp Đồng";
                case SortingMethod.Total_Value_Inquery:
                    return "Tổng số Báo Giá";
                case SortingMethod.Total_Value_Contract_Signed:
                    return "Tổng giá trị HĐ đã kí";
                default:
                    break;
            }
            return "Theo ID Khách Hàng";
        }

        public static string TransferDurationTimeToString(DurationTime durationTime)
        {
            switch (durationTime)
            {
                case DurationTime.Today:
                    return "Hôm nay";
                case DurationTime.This_Week:
                    return "Tuần này";
                case DurationTime.This_Month:
                    return "Tháng này";
                case DurationTime.This_Quarter:
                    return "Quý này";
                case DurationTime.Last_Six_Month:
                    return "6 Tháng qua";
                case DurationTime.Begin_Year_Now:
                    return "Đầu năm đến nay";
            }
            return "Toàn thời gian";
        }
    }
    public enum SortingMethod
    {
        Sort_By_ID = 0,

        Sort_A_Z = 1,
        Sort_Z_A = 2,
        Total_Contract = 3,
        Total_Value_Inquery = 4,
        Total_Value_Contract_Signed = 5,
    }
    public enum DurationTime
    {
        Today = 0,

        This_Week = 1,
        This_Month = 2,
        This_Quarter = 3,
        Last_Six_Month = 4,
        Begin_Year_Now = 5,
        All_Time = 6,
    }
}
