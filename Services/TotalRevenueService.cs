using vp_back_end.DAO;
using vp_back_end.Models;

namespace vp_back_end.Services;

public class TotalRevenueService(TotalRevenueDAO dao)
{
    private readonly TotalRevenueDAO totalRevenueDAO = dao;

    public async Task<float> GetMonthAsync(int month, int year)
    {
        return await totalRevenueDAO.GetMonthAsync(month, year);
    }
    public async Task<float> GetYearAsync(int year)
    {
        return await totalRevenueDAO.GetYearAsync(year);
    }
}
