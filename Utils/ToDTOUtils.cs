using System;
using vp_back_end.DTO;
using vp_back_end.Models;

namespace vp_back_end.Utils;

public static class ToDTOUtils
{
    public static List<FoodCategoryDTO> ToFoodCategoryDTOList(List<FoodCategory> list)
    {
        List<FoodCategoryDTO> dtoList = [];
        foreach (var item in list)
        {
            FoodCategoryDTO dto = new()
            {
                Id = item.Id,
                Name = item.Name
            };
            dtoList.Add(dto);
        }
        return dtoList;
    }
    public static FoodCategoryDTO ToFoodCategoryDTO(FoodCategory cat)
    {
        return new FoodCategoryDTO
        {
            Id = cat.Id,
            Name = cat.Name
        };
    }

    public static FoodDTO ToFoodDTO(Food food)
    {
        return new FoodDTO
        {
            Id = food.Id,
            Name = food.Name,
            IdCategory = food.IdCategory,
            Price = food.Price,
            ImageLink = food.ImageLink,
            CategoryName = food.FoodCategory.Name
        };
    }

    public static List<FoodDTO> ToFoodDTOList(List<Food> list)
    {
        List<FoodDTO> dtoList = [];
        foreach (var food in list)
        {
            FoodDTO dto = new()
            {
                Id = food.Id,
                Name = food.Name,
                IdCategory = food.IdCategory,
                Price = food.Price,
                ImageLink = food.ImageLink,
                CategoryName = food.FoodCategory.Name
            };
            dtoList.Add(dto);
        }
        return dtoList;
    }

    public static List<TableFoodDTO> ToTableFoodDTOList(List<TableFood> list)
    {
        List<TableFoodDTO> dtoList = new List<TableFoodDTO>();
        foreach (var item in list)
        {
            TableFoodDTO dto = new TableFoodDTO();
            dto.Id = item.Id;
            dto.Name = item.Name;
            dto.Status = item.Status;
            dtoList.Add(dto);
        }
        return dtoList;
    }

    public static TableFoodDTO ToTableFoodDTO(TableFood tb, Bill bill)
    {
        int billId = -1;
        if (bill != null)
        {
            billId = bill.Id;
        }
        return new TableFoodDTO
        {
            Id = tb.Id,
            Name = tb.Name,
            Status = tb.Status,
            UnpaidBillId = billId
        };
    }
    public static List<BillInfoDTO> ToBillInfoDTOList(List<BillInfo> list)
    {
        List<BillInfoDTO> dtoList = new List<BillInfoDTO>();
        foreach (var item in list)
        {
            BillInfoDTO dto = ToBillInfoDTO(item);
            dtoList.Add(dto);
        }
        return dtoList;
    }

    public static BillInfoDTO ToBillInfoDTO(BillInfo billInfo)
    {
        BillInfoDTO dto = new()
        {
            Id = billInfo.Id,
            IdFood = billInfo.Food.Id,
            FoodName = billInfo.Food.Name,
            Count = billInfo.Count
        };
        return dto;
    }

    public static List<BillDTO> ToBillDTOList(List<Bill> list)
    {
        List<BillDTO> dtoList = [];
        foreach (var item in list)
        {
            dtoList.Add(ToBillDTO(item));
        }
        return dtoList;
    }
    public static BillDTO ToBillDTO(Bill bill)
    {
        var billInfoList = bill.BillInfos;
        var billInfoListDTO = ToBillInfoDTOList(billInfoList);
        return new BillDTO()
        {
            Id = bill.Id,
            DateCheckIn = bill.DateCheckIn,
            DateCheckOut = bill.DateCheckOut,
            IdTable = bill.IdTable,
            Status = bill.Status,
            Discount = bill.Discount,
            TotalPrice = bill.TotalPrice,
            TableName = bill.TableFood.Name,
            BillInfos = billInfoListDTO
        };
    }

    public static List<AccountDTO> ToAccountDTO(List<Account> list)
    {
        List<AccountDTO> dtoList = new List<AccountDTO>();
        foreach (var item in list)
        {
            AccountDTO dto = new AccountDTO();
            dto.UserName = item.UserName;
            dto.DisplayName = item.DisplayName;
            dto.PassWord = item.PassWord;
            dto.Type = item.Type;
            dtoList.Add(dto);
        }
        return dtoList;
    }

    public static AccountDTO ToAccountDTO(Account item)
    {
        AccountDTO dto = new()
        {
            UserName = item.UserName,
            DisplayName = item.DisplayName,
            PassWord = item.PassWord,
            Type = item.Type
        };
        return dto;
    }

    public static List<BillDTO> ToBillDTO(List<Bill> list)
    {
        List<BillDTO> dtoList = new List<BillDTO>();
        foreach (var item in list)
        {
            BillDTO dto = new BillDTO();
            dto.Id = item.Id;
            dto.DateCheckIn = item.DateCheckIn;
            dto.DateCheckOut = item.DateCheckOut;
            dto.IdTable = item.IdTable;
            dto.Status = item.Status;
            dto.Discount = item.Discount;
            dto.TotalPrice = item.TotalPrice;


            dtoList.Add(dto);
        }
        return dtoList;
    }
}
