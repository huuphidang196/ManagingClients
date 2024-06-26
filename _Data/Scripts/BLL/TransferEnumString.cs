﻿using System;
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

        public static string TransferPostionToString(Position pos)
        {
            switch (pos)
            {
                case Position.PRESIDENT:
                    return "Chủ Tịch";
                case Position.DIRECTOR:
                    return "Giám Đốc";
                case Position.HEAD_OF_DEPARTMENT:
                    return "Trưởng Phòng";
                case Position.DEPUTY_OF_DEPARTMENT:
                    return "Phó Phòng";
                case Position.LEADER_TEAM_DEPARTMENT:
                    return "Trưởng Nhóm";
                case Position.EMPLOYEE:
                    return "Nhân viên";
                default:
                    break;
            }

            return "Khách";
        }
        public static Position TransferStringToPosition(string str_Pos)
        {
            switch (str_Pos)
            {
                case "Chủ Tịch" :
                    return Position.PRESIDENT;
                case "Giám Đốc" :
                    return Position.DIRECTOR;
                case "Trưởng Phòng" :
                    return Position.HEAD_OF_DEPARTMENT;
                case "Phó Phòng" :
                    return Position.DEPUTY_OF_DEPARTMENT;
                case "Trưởng Nhóm" :
                    return Position.LEADER_TEAM_DEPARTMENT;
                case "Nhân viên" :
                    return Position.EMPLOYEE;
                default:
                    break;
            }

            return Position.VISITOR;
        }

        public static string TransferStatusOrderToString(StatusOrder statusOrder)
        {
            switch (statusOrder)
            {
                case StatusOrder.Require_Inquiry:
                    return "Yêu cầu Báo Giá";
                case StatusOrder.Send_Inquiry:
                    return "Đã gủi Báo Giá";
                case StatusOrder.Require_Contract:
                    return "Yêu cầu Hợp Đồng";
                case StatusOrder.Cancel_Contract:
                    return "Đã Hủy Hợp Đồng";
                case StatusOrder.Wait_Pay_Complete:
                    return "Chưa Hoàn thành Thanh Toán";
                case StatusOrder.Delivering:
                    return "Đang vận chuyển đến VN";
                case StatusOrder.Arriving_Customer:
                    return "Đang vận chuyển đến Khách Hàng";
                default:
                    break;
            }

            return "Hoàn Thành Hợp Đồng";
        }
        public static StatusOrder TransferStringToStatusOrder(string str_StatusOrder)
        {
            switch (str_StatusOrder)
            {
                case "Yêu cầu Báo Giá":
                    return StatusOrder.Require_Inquiry;
                case "Đã gủi Báo Giá":
                    return StatusOrder.Send_Inquiry;
                case "Yêu cầu Hợp Đồng":
                    return StatusOrder.Require_Contract;
                case "Đã Hủy Hợp Đồng":
                    return StatusOrder.Cancel_Contract;
                case "Chưa Hoàn thành Thanh Toán":
                    return StatusOrder.Wait_Pay_Complete;
                case "Đang vận chuyển đến VN":
                    return StatusOrder.Delivering;
                case "Đang vận chuyển đến Khách Hàng":
                    return StatusOrder.Arriving_Customer;
                default:
                    break;
            }

            return StatusOrder.Finished_Contract;
        }

        public static string TransferLevelAccessToString(LevelAccess levelAccess)
        {
            switch (levelAccess)
            {
                case LevelAccess.LEVEL_05:
                    return levelAccess.ToString() + " - CT,GĐ";
                case LevelAccess.LEVEL_04:
                    return levelAccess.ToString() + " - TP";
                case LevelAccess.LEVEL_03:
                    return levelAccess.ToString() + " - PP";
                case LevelAccess.LEVEL_02:
                    return levelAccess.ToString() + " - TN";
                case LevelAccess.LEVEL_01:
                    return levelAccess.ToString() + " - NV";
                default:
                    break;
            }
            return levelAccess.ToString() + " - GUEST";
        }
        public static LevelAccess TransferStringToLevelAccess(string str_LevelAccess)
        {

            switch (str_LevelAccess)
            {
                case ("LEVEL_05 - CT,GĐ"):
                    return LevelAccess.LEVEL_05;
                case "LEVEL_04 - TP":
                    return LevelAccess.LEVEL_04;
                case "LEVEL_03 - PP":
                    return LevelAccess.LEVEL_03;
                case "LEVEL_02 - TN":
                    return LevelAccess.LEVEL_02;
                case "LEVEL_01 - NV":
                    return LevelAccess.LEVEL_01;
                default:
                    break;
            }
            return LevelAccess.LEVEL_ZERO;
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

    public enum StatusOrder
    {
        Require_Inquiry = 0,

        Send_Inquiry = 1,

        Require_Contract = 2,

        Cancel_Contract = 3,

        Wait_Pay_Complete = 4,

        Delivering = 5,

        Arriving_Customer = 6,

        Finished_Contract = 7
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
