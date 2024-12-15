using vp_back_end.DAO;
using vp_back_end.DTO;
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
            return ToDTOUtils.ToFoodCategoryDTO(list);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<FoodCategoryDTO>();
        }
    }
}
