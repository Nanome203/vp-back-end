using System;
using System.Reflection.Metadata;
using vp_back_end.DTO;
using vp_back_end.Models;

namespace vp_back_end.Utils;

public static class ToDAOUtils
{
    public static Food ToFoodDAO(FoodDTO food)
    {
        return new Food
        {
            Id = food.Id,
            Name = food.Name,
            IdCategory = food.IdCategory,
            Price = food.Price,
            ImageLink = food.ImageLink,
            IsHidden = food.IsHidden,
        };
    }

    public static Bill ToBillDAO(BillDTO billDTO)
    {
        var billInfoDTOList = billDTO.BillInfos;
        List<BillInfo> billInfoList = [];
        foreach (BillInfoDTO billInfoDTO in billInfoDTOList)
        {
            billInfoList.Add(ToBillInfoDAO(billInfoDTO, billDTO));
        }
        return new Bill
        {
            DateCheckIn = billDTO.DateCheckIn,
            DateCheckOut = billDTO.DateCheckOut,
            IdTable = billDTO.IdTable,
            Status = billDTO.Status,
            Discount = billDTO.Discount,
            TotalPrice = billDTO.TotalPrice,
            BillInfos = billInfoList
        };
    }

    public static BillInfo ToBillInfoDAO(BillInfoDTO billInfoDTO, BillDTO billDTO)
    {
        return new BillInfo
        {
            Id = billInfoDTO.Id,
            IdBill = billDTO.Id,
            IdFood = billInfoDTO.IdFood,
            Count = billInfoDTO.Count,
        };
    }
}
