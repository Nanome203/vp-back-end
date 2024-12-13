using Microsoft.EntityFrameworkCore;
using vp_back_end.Data;
using vp_back_end.Models;

namespace vp_back_end.DAO;

public class FoodCategoryDAO(RestaurantContext context)
{
    private readonly RestaurantContext _context = context;
    public async Task<int> Create(FoodCategory category)
    {
        await _context.FoodCategories.AddAsync(category);
        return await _context.SaveChangesAsync(); // Return the number of affected rows (>=0)
    }
    public async Task<FoodCategory?> Get(int id)
    {
        return await _context.FoodCategories.AsNoTracking().SingleOrDefaultAsync(f => f.Id == id);
    }

    public async Task<List<FoodCategory>> GetAll()
    {
        return await _context.FoodCategories.AsNoTracking().ToListAsync();
    }
    public async Task<int> Update(FoodCategory category)
    {
        var categoryToUpdate = await Get(category.Id);
        if (categoryToUpdate != null)
        {
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.IsHidden = category.IsHidden;
        }
        return await _context.SaveChangesAsync();

    }

    public async Task<int> Delete(int id)
    {
        var categoryToDelete = await Get(id);
        if (categoryToDelete != null)
        {
            _context.FoodCategories.Remove(categoryToDelete);
        }
        return await _context.SaveChangesAsync();
    }

}
