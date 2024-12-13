using Microsoft.EntityFrameworkCore;
using vp_back_end.Data;
using vp_back_end.Models;

namespace vp_back_end.DAO;

public class AccountDAO(RestaurantContext context)
{
    private readonly RestaurantContext _context = context;

    public async Task<int> Create(Account account)
    {
        await _context.Accounts.AddAsync(account);
        return await _context.SaveChangesAsync(); // Return the number of affected rows (>=0)
    }
    public async Task<Account?> Get(string username)
    {
        return await _context.Accounts.SingleOrDefaultAsync(a => a.UserName == username && a.IsHidden == 0);
    }

    public async Task<List<Account>> GetAll()
    {
        return await _context.Accounts.Where(a => a.IsHidden == 0).ToListAsync();
    }
    public async Task<int> Update(Account account)
    {
        var accountToUpdate = await Get(account.UserName!);
        if (accountToUpdate != null)
        {
            accountToUpdate.DisplayName = account.DisplayName;
            accountToUpdate.PassWord = account.PassWord;
            accountToUpdate.Type = account.Type;
        }
        return await _context.SaveChangesAsync();

    }

    public async Task<int> Delete(string username)
    {
        var accountToDelete = await Get(username);
        if (accountToDelete != null)
        {
            accountToDelete.IsHidden = 1;
        }
        return await _context.SaveChangesAsync();
    }
}
