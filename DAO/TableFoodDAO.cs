using Microsoft.EntityFrameworkCore;
using vp_back_end.Data;
using vp_back_end.Models;

namespace vp_back_end.DAO;

public class TableFoodDAO(RestaurantContext context)
{
    private readonly RestaurantContext _context = context;
    public async Task<int> CreateAsync(TableFood table)
    {
        await _context.Tables.AddAsync(table);
        return await _context.SaveChangesAsync(); // Return the number of affected rows (>=0)
    }
    public async Task<TableFood?> GetAsync(int id)
    {
        return await _context.Tables.SingleOrDefaultAsync(b => b.Id == id && b.IsHidden == 0);
    }

    public async Task<List<TableFood>> GetAllAsync()
    {
        return await _context.Tables.Where(b => b.IsHidden == 0).ToListAsync();
    }
    public async Task<int> UpdateAsync(TableFood table)
    {
        var tableToUpdate = await GetAsync(table.Id);
        if (tableToUpdate != null)
        {
            tableToUpdate.Name = table.Name;
            tableToUpdate.Status = table.Status;
            tableToUpdate.IsHidden = table.IsHidden;
        }
        return await _context.SaveChangesAsync();

    }

    public async Task<int> DeleteAsync(int id)
    {
        var tableToDelete = await GetAsync(id);
        if (tableToDelete != null)
        {
            tableToDelete.IsHidden = 1;
        }
        return await _context.SaveChangesAsync();
    }
}
