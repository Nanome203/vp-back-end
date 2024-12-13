using Microsoft.EntityFrameworkCore;
using vp_back_end.Data;
using vp_back_end.Models;

namespace vp_back_end.DAO;

public class FoodDAO(RestaurantContext context)
{
    private readonly RestaurantContext _context = context;
    public async Task<int> Create(Food food)
    {
        await _context.Foods.AddAsync(food);
        return await _context.SaveChangesAsync(); // Return the number of affected rows (>=0)
    }
    public async Task<Food?> Get(int id)
    {
        return await _context.Foods.AsNoTracking().SingleOrDefaultAsync(f => f.Id == id);
    }

    public async Task<List<Food>> GetAll()
    {
        return await _context.Foods.AsNoTracking().ToListAsync();
    }
    public async Task<int> Update(Food food)
    {
        var foodToUpdate = await Get(food.Id);
        if (foodToUpdate != null)
        {
            foodToUpdate.Name = food.Name;
            foodToUpdate.IdCategory = food.IdCategory;
            foodToUpdate.Price = food.Price;
            foodToUpdate.IsHidden = food.IsHidden;
        }
        return await _context.SaveChangesAsync();

    }

    public async Task<int> Delete(int id)
    {
        var foodToDelete = await Get(id);
        if (foodToDelete != null)
        {
            _context.Foods.Remove(foodToDelete);
        }
        return await _context.SaveChangesAsync();
    }

}
