using Microsoft.EntityFrameworkCore;
using vp_back_end.Data;
using vp_back_end.Models;

namespace vp_back_end.DAO;

public class TotalRevenueDAO(RestaurantContext context)
{
    private readonly RestaurantContext _context = context;
    public async Task<float> GetMonthAsync(int month, int year)
    {
        return await _context.Bills.Where(b => b.DateCheckOut.HasValue &&
                b.DateCheckOut.Value.Month == month && b.Status == 1 &&
                b.DateCheckOut.Value.Year == year)
    .SumAsync(b => b.TotalPrice);
    }
    public async Task<float> GetYearAsync(int year)
    {
        return await _context.Bills.Where(b => b.DateCheckOut.HasValue &&
                b.Status == 1 &&
                b.DateCheckOut.Value.Year == year)
    .SumAsync(b => b.TotalPrice);
    }
}
