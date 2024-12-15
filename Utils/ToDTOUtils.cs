using System;
using vp_back_end.DTO;
using vp_back_end.Models;

namespace vp_back_end.Utils;

public static class ToDTOUtils
{
    public static List<FoodCategoryDTO> ToFoodCategoryDTO(List<FoodCategory> list)
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

    public static List<FoodDTO> ToFoodDTO(List<Food> list)
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
}
