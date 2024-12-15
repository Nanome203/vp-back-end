using Microsoft.EntityFrameworkCore;
using vp_back_end.Data;
using vp_back_end.Models;

namespace vp_back_end.DAO;

public class BillDAO(RestaurantContext context)
{
    private readonly RestaurantContext _context = context;

    public async Task<List<Bill>> GetAllAsync(DateTime dateStart, DateTime dateEnd)
    {
        return await _context.Bills.Where(b => b.IsHidden == 0 
            && b.DateCheckOut <= dateEnd   
            && b.DateCheckIn >= dateStart)
        .ToListAsync();
    }
}
