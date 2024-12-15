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
}
