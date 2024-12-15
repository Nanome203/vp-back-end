using Microsoft.EntityFrameworkCore;
using vp_back_end.Data;
using vp_back_end.Models;

namespace vp_back_end.DAO;

public class BillInfoDAO(RestaurantContext context)
{

    private readonly RestaurantContext _context = context;
    public async Task<int> CreateAsync(BillInfo billInfo)
    {
        // var existingBill = await _context.Bills
        //     .FirstOrDefaultAsync(b => b.Id == billInfo.Bill.Id);

        // if (existingBill == null)
        // {
        //     _context.Bills.Add(billInfo.Bill);  // Thêm mới Bill
        // }
        // else
        // {
        //     // Nếu Bill đã tồn tại, gán lại cho BillInfo để liên kết
        //     billInfo.IdBill = existingBill.Id;
        // }

        // var existingFood = await _context.Foods
        //     .FirstOrDefaultAsync(f => f.Id == billInfo.Food.Id);

        // billInfo.IdFood = existingFood.Id;

        // Thêm BillInfo vào bảng BillInfo
        await _context.BillInfo.AddAsync(billInfo);

        // Lưu các thay đổi vào cơ sở dữ liệu
        return await _context.SaveChangesAsync(); // Return the number of affected rows (>=0)
    }
    public async Task<BillInfo?> GetAsync(int id)
    {
        return await _context.BillInfo.SingleOrDefaultAsync(b => b.Id == id && b.IsHidden == 0);
    }

    public async Task<List<BillInfo>> GetAllAsync(int IdTableFood, int IdBill)
    {
        return await _context.BillInfo
            .Include(b => b.Bill)
            .ThenInclude(b => b.TableFood)
            .Where(b => b.IsHidden == 0 && b.Bill.IsHidden == 0
                    && b.Bill.TableFood.IsHidden == 0
                    && b.Bill.Id == IdBill
                    && b.Bill.TableFood.Status == "Có khách"
                    && b.Bill.TableFood.Id == IdTableFood)
            .ToListAsync();
    }
    public async Task<int> UpdateAsync(BillInfo billInfo)
    {
        var billInfoToUpdate = await GetAsync(billInfo.Id);
        if (billInfoToUpdate != null)
        {
            billInfoToUpdate.Id = billInfo.Id;
            billInfoToUpdate.IdBill = billInfo.IdBill;
            billInfoToUpdate.IdFood = billInfo.IdFood;
            billInfoToUpdate.Count = billInfo.Count;
        }
        return await _context.SaveChangesAsync();

    }

    public async Task<int> DeleteAsync(int id)
    {
        var billToDelete = await GetAsync(id);
        if (billToDelete != null)
        {
            billToDelete.IsHidden = 1;
        }
        return await _context.SaveChangesAsync();
    }

}
