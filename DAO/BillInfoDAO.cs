using Microsoft.EntityFrameworkCore;
using vp_back_end.Data;
using vp_back_end.Models;

namespace vp_back_end.DAO;

public class BillInfoDAO(RestaurantContext context)
{
    private readonly RestaurantContext _context = context;
    public async Task<int> CreateAsync(BillInfo billInfo)
    {
        await _context.BillInfo.AddAsync(billInfo);
        return await _context.SaveChangesAsync(); // Return the number of affected rows (>=0)
    }
    public async Task<BillInfo?> GetAsync(int id)
    {
        return await _context.BillInfo.SingleOrDefaultAsync(b => b.Id == id && b.IsHidden == 0);
    }

    public async Task<List<BillInfo>> GetAllAsync()
    {
        return await _context.BillInfo.Where(b => b.IsHidden == 0).ToListAsync();
    }
    public async Task<int> UpdateAsync(BillInfo billInfo)
    {
        var billInfoToUpdate = await GetAsync(billInfo.Id);
        if (billInfoToUpdate != null)
        {
            billInfoToUpdate.IdBill = billInfo.IdBill;
            billInfoToUpdate.IdFood = billInfo.IdFood;
            billInfoToUpdate.Count = billInfo.Count;
        }
        return await _context.SaveChangesAsync();

    }

    public async Task<int> DeleteAsync(int id)
    {
        var billToDelete = await GetAsync(id);
        if (billToDelete != null)
        {
            billToDelete.IsHidden = 1;
        }
        return await _context.SaveChangesAsync();
    }

}
