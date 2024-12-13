using Microsoft.EntityFrameworkCore;
using vp_back_end.Data;
using vp_back_end.Models;

namespace vp_back_end.DAO;

public class BillInfoDAO(RestaurantContext context)
{
    private readonly RestaurantContext _context = context;
    public async Task<int> Create(BillInfo billInfo)
    {
        await _context.BillInfo.AddAsync(billInfo);
        return await _context.SaveChangesAsync(); // Return the number of affected rows (>=0)
    }
    public async Task<BillInfo?> Get(int id)
    {
        return await _context.BillInfo.AsNoTracking().SingleOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<BillInfo>> GetAll()
    {
        return await _context.BillInfo.AsNoTracking().ToListAsync();
    }
    public async Task<int> Update(BillInfo billInfo)
    {
        var billInfoToUpdate = await Get(billInfo.Id);
        if (billInfoToUpdate != null)
        {
            billInfoToUpdate.IdBill = billInfo.IdBill;
            billInfoToUpdate.IdFood = billInfo.IdFood;
            billInfoToUpdate.Count = billInfo.Count;
        }
        return await _context.SaveChangesAsync();

    }

    public async Task<int> Delete(int id)
    {
        var billToDelete = await Get(id);
        if (billToDelete != null)
        {
            _context.BillInfo.Remove(billToDelete);
        }
        return await _context.SaveChangesAsync();
    }

}
