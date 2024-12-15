using System;
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
}
