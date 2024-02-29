using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using WebSalesMVC.Data;
using WebSalesMVC.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionStr = "server=localhost;userid=alex;password=1234;database=saleswebmvcappdb";
builder.Services.AddDbContext<WebSalesMVCContext>(options =>
    options.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr)));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Adicionando injeção do SeedingServices
app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
