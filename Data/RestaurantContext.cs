
using Microsoft.EntityFrameworkCore;
using vp_back_end.Models;

namespace vp_back_end.Data;

public class RestaurantContext : DbContext
{

    public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
    {

    }
    DbSet<Account> Accounts => Set<Account>();
    DbSet<Bill> Bills => Set<Bill>();
    DbSet<BillInfo> BillInfo => Set<BillInfo>();
    DbSet<Food> Foods => Set<Food>();
    DbSet<FoodCategory> FoodCategories => Set<FoodCategory>();
    DbSet<TableFood> Tables => Set<TableFood>();
}
