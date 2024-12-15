using System;
using vp_back_end.DAO;
using vp_back_end.DTO;
using vp_back_end.Models;
using vp_back_end.Utils;

namespace vp_back_end.Services;

public class TableFoodService(TableFoodDAO dao, BillDAO dao2)
{
    private readonly TableFoodDAO tableFoodDAO = dao;
    private readonly BillDAO billDAO = dao2;
    public async Task<List<TableFoodDTO>> GetAllAsync()
    {
        // var list = await tableFoodDAO.GetAllAsync();
        // return ToDTOUtils.ToTableFoodDTOList(list);
        List<TableFoodDTO> list = [];
        var unpaidBill = await billDAO.GetAllUnpaidAsync();
        var tableFoodList = await tableFoodDAO.GetAllAsync();
        foreach (var tableFood in tableFoodList)
        {
            Bill tableFoodUnpaidBill = null;
            foreach (var unpaid in unpaidBill)
            {
                if (unpaid.Status == 0 && tableFood.Id == unpaid.IdTable)
                {
                    tableFoodUnpaidBill = unpaid;
                }
            }
            list.Add(ToDTOUtils.ToTableFoodDTO(tableFood, tableFoodUnpaidBill));
        }
        return list;
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
