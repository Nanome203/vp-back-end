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
        return await _context.SaveChangesAsync();
    }
    public async Task<List<Bill>> GetAllAsync()
    {
        // return await _context.Bills.Where(b => b.IsHidden == 0 
        //     && b.DateCheckOut <= dateEnd   
        //     && b.DateCheckIn >= dateStart)
        // .ToListAsync();
        return await _context.Bills
                    .Include(b => b.TableFood)
                    .Include(b => b.BillInfos)
                    .ThenInclude(b => b.Food)
                    .Where(b => b.IsHidden == 0)
                    .ToListAsync();
    }

    public async Task<List<Bill>> GetAllUnpaidAsync()
    {
        return await _context.Bills
                    .Include(b => b.TableFood)
                    .Include(b => b.BillInfos)
                    .ThenInclude(b => b.Food)
                    .Where(b => b.IsHidden == 0 && b.Status == 0)
                    .ToListAsync();
    }

    public async Task<Bill> GetAsync(int id)
    {
        return await _context.Bills
                    .Include(b => b.TableFood)
                    .Include(b => b.BillInfos)
                    .ThenInclude(b => b.Food)
                    .Where(b => b.IsHidden == 0)
                    .SingleOrDefaultAsync(b => b.Id == id);
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
