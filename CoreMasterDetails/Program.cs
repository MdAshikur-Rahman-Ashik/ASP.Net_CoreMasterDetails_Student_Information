
using CoreMasterDetails.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SheCoreDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("StudentCon")));


var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(name: "Default", pattern: "{controller=Student}/{action=Index}/{id?}");
app.Run();