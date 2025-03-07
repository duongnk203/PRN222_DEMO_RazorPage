using Microsoft.EntityFrameworkCore;
using RazorPageLab.Models;

var builder = WebApplication.CreateBuilder(args);

// Lấy chuỗi kết nối từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("FapSystemDB");

// Đăng ký DbContext để sử dụng SQL Server
builder.Services.AddDbContext<FapSystemDbContext>(options =>
    options.UseSqlServer(connectionString));

// Thêm Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
