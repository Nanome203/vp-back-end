using System;
using vp_back_end.DAO;
using vp_back_end.DTO;
using vp_back_end.Models;
using vp_back_end.Utils;

namespace vp_back_end.Services;

public class FoodService(FoodDAO dao)
{
    private readonly FoodDAO foodDAO = dao;
    public async Task<List<FoodDTO>> GetAllAsync()
    {
        try
        {
            List<Food> foods = await foodDAO.GetAllAsync();
            return ToDTOUtils.ToFoodDTOList(foods);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return [];
        }
    }

    public async Task<int> CreateAsync(FoodDTO dto)
    {
        var dao = ToDAOUtils.ToFoodDAO(dto);
        try
        {
            return await foodDAO.CreateAsync(dao);
        }
        catch
        {
            return 0;
        }
    }

    public async Task<int> UpdateAsync(FoodDTO dto)
    {
        var dao = ToDAOUtils.ToFoodDAO(dto);
        try
        {
            return await foodDAO.UpdateAsync(dao);
        }
        catch
        {
            return 0;
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        try
        {
            return await foodDAO.DeleteAsync(id);
        }
        catch
        {
            return 0;
        }
    }
}
