using Microsoft.EntityFrameworkCore;
using vp_back_end.Data;
using vp_back_end.Models;

namespace vp_back_end.DAO;

public class AccountDAO(RestaurantContext context)
{
    private readonly RestaurantContext _context = context;

    public async Task<int> CreateAsync(Account account)
    {
        await _context.Accounts.AddAsync(account);
        return await _context.SaveChangesAsync(); // Return the number of affected rows (>=0)
    }
    public async Task<bool> CheckExistsAsync(string username, string password)
    {
        var account = await _context.Accounts.SingleOrDefaultAsync(x => x.UserName == username);
        if (account != null)
        {
            return account.PassWord == password;
        }
        return false;
    }
    public async Task<Account?> GetAsync(string username)
    {
        return await _context.Accounts.SingleOrDefaultAsync(a => a.UserName == username);
    }

    public async Task<List<Account>> GetAllAsync(int type)
    {
        return await _context.Accounts.Where(a => a.IsHidden == 0 && a.Type == type).ToListAsync();
    }
    public async Task<int> UpdateAsync(string id, Account account)
    {
        var accountToUpdate = await GetAsync(id!);
        if (accountToUpdate != null)
        {
            accountToUpdate.UserName = id;
            accountToUpdate.DisplayName = account.DisplayName;
            accountToUpdate.PassWord = account.PassWord;
            accountToUpdate.Type = account.Type;
        }
        return await _context.SaveChangesAsync();

    }

    public async Task<int> DeleteAsync(string username)
    {
        var accountToDelete = await GetAsync(username);
        if (accountToDelete != null)
        {
            accountToDelete.IsHidden = 1;
        }
        return await _context.SaveChangesAsync();
    }
}
