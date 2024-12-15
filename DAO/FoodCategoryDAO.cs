using Microsoft.EntityFrameworkCore;
using vp_back_end.Data;
using vp_back_end.Models;

namespace vp_back_end.DAO;

public class FoodCategoryDAO(RestaurantContext context)
{
    private readonly RestaurantContext _context = context;
    public async Task<int> CreateAsync(FoodCategory category)
    {
        await _context.FoodCategories.AddAsync(category);
        return await _context.SaveChangesAsync(); // Return the number of affected rows (>=0)
    }
    public async Task<FoodCategory?> GetAsync(int id)
    {
        return await _context.FoodCategories.SingleOrDefaultAsync(f => f.Id == id && f.IsHidden == 0);
    }

    public async Task<List<FoodCategory>> GetAllAsync()
    {
        return await _context.FoodCategories.Where(f => f.IsHidden == 0).ToListAsync();
    }
    public async Task<int> UpdateAsync(FoodCategory category)
    {
        var categoryToUpdate = await GetAsync(category.Id);
        if (categoryToUpdate != null)
        {
            categoryToUpdate.Id = category.Id;
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.IsHidden = category.IsHidden;
        }
        return await _context.SaveChangesAsync();

    }

    public async Task<int> DeleteAsync(int id)
    {
        var categoryToDelete = await GetAsync(id);
        if (categoryToDelete != null)
        {
            categoryToDelete.IsHidden = 1;
        }
        return await _context.SaveChangesAsync();
    }

}
