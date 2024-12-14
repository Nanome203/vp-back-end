using Microsoft.EntityFrameworkCore;
using vp_back_end.DAO;
using vp_back_end.Data;
using vp_back_end.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
});
// Add the database context
builder.Services.AddDbContext<RestaurantContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
// Add Service Layer
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<BillService>();
builder.Services.AddScoped<BillInfoService>();
builder.Services.AddScoped<FoodService>();
builder.Services.AddScoped<FoodCategoryService>();
builder.Services.AddScoped<TableFoodService>();

// Add DAO 
builder.Services.AddScoped<AccountDAO>();
builder.Services.AddScoped<BillDAO>();
builder.Services.AddScoped<BillInfoDAO>();
builder.Services.AddScoped<FoodDAO>();
builder.Services.AddScoped<FoodCategoryDAO>();
builder.Services.AddScoped<TableFoodDAO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
