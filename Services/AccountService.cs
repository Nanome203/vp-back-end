using System;
using Microsoft.AspNetCore.Mvc;
using vp_back_end.DAO;
using vp_back_end.Models;

namespace vp_back_end.Services;

public class AccountService(AccountDAO dao)
{
    private readonly AccountDAO accountDAO = dao;

    public async Task<List<Account>> GetAllAsync()
    {
        return await accountDAO.GetAllAsync();
    }
    public async Task<Account> GetAsync(string username)
    {
        return await accountDAO.GetAsync(username);
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
}
