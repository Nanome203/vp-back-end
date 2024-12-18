using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using vp_back_end.DAO;
using vp_back_end.DTO;
using vp_back_end.Models;
using vp_back_end.Utils;

namespace vp_back_end.Services;

public class AccountService(AccountDAO dao)
{
    private readonly AccountDAO accountDAO = dao;

    public async Task<Account> CheckExistsAsync(string username, string password)
    {
        try
        {
            var account = await accountDAO.CheckExistsAsync(username);
            if (account == null || account.PassWord != password) return null;
            return account;
        }
        catch
        {
            return null;
        }
    }
    public async Task<List<Account>> GetAllAsync(int type)
    {
        return await accountDAO.GetAllAsync(type);
    }
    public async Task<AccountDTO> GetAsync(string username)
    {
        var account = await accountDAO.GetAsync(username);
        return ToDTOUtils.ToAccountDTO(account);
    }

    public async Task<int> CreateAsync(Account account)
    {
        try
        {
            var result = await accountDAO.CreateAsync(account);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oh shit. Exception occurred dumb ass");
            return 0;
        }

        return 1;
    }

    public async Task<int> UpdateAsync(string id, Account account)
    {
        try
        {
            var result = await accountDAO.UpdateAsync(id, account);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oh shit. Exception occurred dumb ass");
            return 0;
        }

        return 1;
    }

    public async Task<int> DeleteAsync(string id)
    {
        try
        {
            var result = await accountDAO.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oh shit. Exception occurred dumb ass");
            return 0;
        }

        return 1;
    }
}
