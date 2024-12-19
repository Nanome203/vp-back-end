using System;
using vp_back_end.DAO;
using vp_back_end.DTO;
using vp_back_end.Models;
using vp_back_end.Utils;

namespace vp_back_end.Services;

public class BillService(BillDAO dao, TableFoodDAO dao2)
{
    private readonly BillDAO billDAO = dao;
    private readonly TableFoodDAO tableFoodDAO = dao2;

    public async Task<int> EditBillAsync(BillEditDTO bill, int id)
    {
        return await billDAO.EditBillAsync(bill, id);
    }
    public async Task<int> CreateAsync(BillDTO billDTO)
    {
        try
        {
            var tableFoodToUpdate = await tableFoodDAO.GetAsync(billDTO.IdTable);
            if (tableFoodToUpdate.Status == "Đang hoạt động")
                return 0;
            tableFoodToUpdate.Status = "Đang hoạt động";
            return await billDAO.CreateAsync(ToDAOUtils.ToBillDAO(billDTO));
        }
        catch
        {
            return 0;
        }
    }
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

    public async Task<int> PayBillAsync(int id)
    {
        return await billDAO.PayBillAsync(id);
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
