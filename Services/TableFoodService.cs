using System;
using vp_back_end.DAO;
using vp_back_end.DTO;
using vp_back_end.Models;
using vp_back_end.Utils;

namespace vp_back_end.Services;

public class TableFoodService(TableFoodDAO dao)
{
    private readonly TableFoodDAO tableFoodDAO = dao;
    public async Task<List<TableFoodDTO>> GetAllAsync()
    {
        var list = await tableFoodDAO.GetAllAsync();
        return ToDTOUtils.ToTableFoodDTOList(list);
    }
    public async Task<int> CreateAsync(TableFood tableFood)
    {
        try
        {
            var result = await tableFoodDAO.CreateAsync(tableFood);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oh shit. Exception occurred dumb ass");
            return 0;
        }

        return 1;
    }

    public async Task<int> UpdateAsync(TableFood tableFood)
    {
        try
        {
            var result = await tableFoodDAO.UpdateAsync(tableFood);
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
            var result = await tableFoodDAO.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oh shit. Exception occurred dumb ass");
            return 0;
        }

        return 1;
    }
}
