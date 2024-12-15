using vp_back_end.DAO;
using vp_back_end.DTO;
using vp_back_end.Models;
using vp_back_end.Utils;

namespace vp_back_end.Services;

public class FoodCategoryService(FoodCategoryDAO dao)
{
    private readonly FoodCategoryDAO foodCategoryDAO = dao;

    public async Task<List<FoodCategoryDTO>> GetAllAsync()
    {
        try
        {
            var list = await foodCategoryDAO.GetAllAsync();
            return ToDTOUtils.ToFoodCategoryDTOList(list);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<FoodCategoryDTO>();
        }
    }
    public async Task<int> CreateAsync(FoodCategory foodCategory)
    {
        try
        {
            var result = await foodCategoryDAO.CreateAsync(foodCategory);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oh shit. Exception occurred dumb ass");
            return 0;
        }

        return 1;
    }

    public async Task<int> UpdateAsync(FoodCategory foodCategory)
    {
        try
        {
            var result = await foodCategoryDAO.UpdateAsync(foodCategory);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oh shit. Exception occurred dumb ass");
            return 0;
        }

        return 1;
    }

    public async Task<int> DeleteAsync(int id)
    {
        try
        {
            var result = await foodCategoryDAO.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oh shit. Exception occurred dumb ass");
            return 0;
        }

        return 1;
    }
}
