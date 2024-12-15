using System;
using vp_back_end.DAO;
using vp_back_end.DTO;
using vp_back_end.Models;
using vp_back_end.Utils;

namespace vp_back_end.Services;

public class BillInfoService(BillInfoDAO dao)
{
    private readonly BillInfoDAO billInfoDAO = dao;

    public async Task<List<BillInfoDTO>> GetAllAsync(int IdTableFood, int IdBill)
    {
        try
        {
            var list = await billInfoDAO.GetAllAsync(IdTableFood, IdBill);
            return ToDTOUtils.ToBillInfoDTO(list);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<BillInfoDTO>();
        }
    }
    public async Task<int> CreateAsync(BillInfo billInfo)
    {
        try
        {
            var result = await billInfoDAO.CreateAsync(billInfo);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oh shit. Exception occurred dumb ass");
            return 0;
        }

        return 1;
    }

    public async Task<int> UpdateAsync(BillInfo billInfo)
    {
        try
        {
            var result = await billInfoDAO.UpdateAsync(billInfo);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oh shit. Exception occurred dumb ass");
            return 0;
        }

        return 1;
    }

    public async Task<int> DeleteAsync(int id)
    {
        try
        {
            var result = await billInfoDAO.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oh shit. Exception occurred dumb ass");
            return 0;
        }

        return 1;
    }
}
