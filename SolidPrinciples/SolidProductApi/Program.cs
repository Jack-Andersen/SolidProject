global using Microsoft.EntityFrameworkCore;
global using SolidProductApi.Data;
global using SolidProductApi.Services;
using SolidProductApi.Services.ProductServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IKeyboardService, KeyboardService>();

builder.Services.AddSqlite<DataContext>("Data Source=SolidProject.db");

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
