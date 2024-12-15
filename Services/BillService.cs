using System;
using vp_back_end.DAO;
using vp_back_end.Models;

namespace vp_back_end.Services;

public class BillService(BillDAO dao)
{
    private readonly BillDAO billDAO = dao;

    

    public async Task<List<Bill>> GetAllAsync(DateTime dateStart, DateTime dateEnd)
    {
        var bills = await billDAO.GetAllAsync(dateStart, dateEnd);
    
    }
}
