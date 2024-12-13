using Microsoft.EntityFrameworkCore;
using vp_back_end.Data;
using vp_back_end.Models;

namespace vp_back_end.DAO;

public class BillDAO(RestaurantContext context)
{
    private readonly RestaurantContext _context = context;
    public async Task<int> CreateAsync(Bill bill)
    {
        await _context.Bills.AddAsync(bill);
        return await _context.SaveChangesAsync(); // Return the number of affected rows (>=0)
    }
    public async Task<Bill?> GetAsync(int id)
    {
        return await _context.Bills.SingleOrDefaultAsync(b => b.Id == id && b.IsHidden == 0);
    }

    public async Task<List<Bill>> GetAllAsync()
    {
        return await _context.Bills.Where(b => b.IsHidden == 0).ToListAsync();
    }
    public async Task<int> UpdateAsync(Bill bill)
    {
        var billToUpdate = await GetAsync(bill.Id);
        if (billToUpdate != null)
        {
            billToUpdate.DateCheckIn = bill.DateCheckIn;
            billToUpdate.DateCheckOut = bill.DateCheckOut;
            billToUpdate.IdTable = bill.IdTable;
            billToUpdate.IsServed = bill.IsServed;
            billToUpdate.Status = bill.Status;
            billToUpdate.Discount = bill.Discount;
            billToUpdate.TotalPrice = bill.TotalPrice;
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
