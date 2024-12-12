
using Microsoft.EntityFrameworkCore;
using vp_back_end.Models;

namespace vp_back_end.Data;

public class RestaurantContext : DbContext
{

    public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
    {

    }
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Bill> Bills => Set<Bill>();
    public DbSet<BillInfo> BillInfo => Set<BillInfo>();
    public DbSet<Food> Foods => Set<Food>();
    public DbSet<FoodCategory> FoodCategories => Set<FoodCategory>();
    public DbSet<TableFood> Tables => Set<TableFood>();
}
