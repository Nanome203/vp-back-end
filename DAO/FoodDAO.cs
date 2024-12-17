using Microsoft.EntityFrameworkCore;
using vp_back_end.Data;
using vp_back_end.Models;

namespace vp_back_end.DAO;

public class FoodDAO(RestaurantContext context)
{
    private readonly RestaurantContext _context = context;
    public async Task<int> CreateAsync(Food food)
    {
        await _context.Foods.AddAsync(food);
        return await _context.SaveChangesAsync(); // Return the number of affected rows (>=0)
    }
    public async Task<Food?> GetAsync(int id)
    {
        return await _context.Foods.Include(f => f.FoodCategory).SingleOrDefaultAsync(f => f.Id == id && f.IsHidden == 0);
    }

    public async Task<List<Food>> GetAllAsync()
    {
        return await _context.Foods.Include(f => f.FoodCategory).Where(f => f.IsHidden == 0).ToListAsync();
    }
    public async Task<List<Food>> GetAllFoodForPopularityComputingAsync()
    {
        return await _context.Foods.Include(f => f.BillInfos).Where(f => f.IsHidden == 0).ToListAsync();
    }
    public async Task<int> UpdateAsync(Food food)
    {
        var foodToUpdate = await GetAsync(food.Id);
        if (foodToUpdate != null)
        {
            foodToUpdate.Name = food.Name;
            foodToUpdate.IdCategory = food.IdCategory;
            foodToUpdate.ImageLink = food.ImageLink;
            foodToUpdate.Price = food.Price;
            foodToUpdate.IsHidden = food.IsHidden;
        }
        return await _context.SaveChangesAsync();

    }

    public async Task<int> DeleteAsync(int id)
    {
        var foodToDelete = await GetAsync(id);
        if (foodToDelete != null)
        {
            foodToDelete.IsHidden = 1;
        }
        return await _context.SaveChangesAsync();
    }

}
