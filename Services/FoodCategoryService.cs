using System;
using vp_back_end.DAO;
using vp_back_end.DTO;
using vp_back_end.Models;

namespace vp_back_end.Services;

public class FoodCategoryService(FoodCategoryDAO dao)
{
    private readonly FoodCategoryDAO foodCategoryDAO = dao;

    public async Task<List<FoodCategoryDTO>> GetAllAsync()
    {
        try
        {
            var list = await foodCategoryDAO.GetAllAsync();
            return ToFoodCategoryDTO(list);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<FoodCategoryDTO>();
        }
    }

    public List<FoodCategoryDTO> ToFoodCategoryDTO(List<FoodCategory> list)
    {
        List<FoodCategoryDTO> dtoList = new List<FoodCategoryDTO>();
        foreach (var item in list)
        {
            FoodCategoryDTO dto = new FoodCategoryDTO();
            dto.Id = item.Id;
            dto.Name = item.Name;
            dtoList.Add(dto);
        }
        return dtoList;
    }
}
