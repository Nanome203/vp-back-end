using Microsoft.EntityFrameworkCore;
using vp_back_end.Data;
using vp_back_end.Models;

namespace vp_back_end.DAO;

public class BillDAO(RestaurantContext context)
{
    private readonly RestaurantContext _context = context;

    public async Task<List<Bill>> GetAllAsync()
    {
        // return await _context.Bills.Where(b => b.IsHidden == 0 
        //     && b.DateCheckOut <= dateEnd   
        //     && b.DateCheckIn >= dateStart)
        // .ToListAsync();
        return await _context.Bills
                    .Include(b => b.TableFood)
                    .Include(b => b.BillInfos)
                    .ThenInclude(b => b.Food).ToListAsync();
    }
}
