using System;
using vp_back_end.DAO;
using vp_back_end.DTO;
using vp_back_end.Models;
using vp_back_end.Utils;

namespace vp_back_end.Services;

public class BillService(BillDAO dao)
{
    private readonly BillDAO billDAO = dao;



    public async Task<List<BillDTO>> GetAllAsync()
    {
        var billDAOList = await billDAO.GetAllAsync();
        return ToDTOUtils.ToBillDTOList(billDAOList);

    }

    public async Task<BillDTO> GetAsync(int id)
    {
        var bill = await billDAO.GetAsync(id);
        if (bill == null)
            return null;
        return ToDTOUtils.ToBillDTO(bill);
    }

    public async Task<int> DeleteAsync(int id)
    {
        try
        {
            return await billDAO.DeleteAsync(id);
        }
        catch
        {
            return 0;
        }
    }
}
