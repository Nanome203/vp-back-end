using Microsoft.EntityFrameworkCore;
using vp_back_end.DAO;
using vp_back_end.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add the database context
builder.Services.AddDbContext<RestaurantContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
// Add Service Layer

// Add DAO 
builder.Services.AddScoped<AccountDAO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
