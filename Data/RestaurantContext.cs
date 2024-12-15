
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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.UserName).UseCollation("SQL_Latin1_General_CP1_CS_AS");
            entity.Property(e => e.DisplayName).HasDefaultValue("Admin");
            entity.Property(e => e.PassWord).HasDefaultValue("0");
            entity.Property(e => e.Type).HasDefaultValue(0);
            entity.Property(e => e.IsHidden).HasDefaultValue(0);
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.Property(e => e.DateCheckIn).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.Status).HasDefaultValue(0);
            entity.Property(e => e.Discount).HasDefaultValue(0);
            entity.Property(e => e.TotalPrice).HasDefaultValue(0);
            entity.Property(e => e.IsHidden).HasDefaultValue(0);
        });

        modelBuilder.Entity<BillInfo>(entity =>
        {
            entity.Property(e => e.Count).HasDefaultValue(0);
            entity.Property(e => e.IsHidden).HasDefaultValue(0);
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.Property(e => e.Name).HasDefaultValue("Chưa đặt tên");
            entity.Property(e => e.Price).HasDefaultValue(0);
            entity.Property(e => e.ImageLink).HasDefaultValue("unavailable");
            entity.Property(e => e.IsHidden).HasDefaultValue(0);
        });

        modelBuilder.Entity<FoodCategory>(entity =>
        {
            entity.Property(e => e.Name).HasDefaultValue("Chưa đặt tên");
            entity.Property(e => e.IsHidden).HasDefaultValue(0);
        });

        modelBuilder.Entity<TableFood>(entity =>
        {
            entity.Property(e => e.Name).HasDefaultValue("Chưa đặt tên");
            entity.Property(e => e.Status).HasDefaultValue("Trống");
            entity.Property(e => e.IsHidden).HasDefaultValue(0);
        });
    }
}
