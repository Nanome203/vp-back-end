using System;
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
}
