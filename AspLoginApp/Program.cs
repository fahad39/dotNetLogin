using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AspLoginApp.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AspLoginAppContextConnection") ?? throw new InvalidOperationException("Connection string 'AspLoginAppContextConnection' not found.");

builder.Services.AddDbContext<AspLoginAppContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AspLoginAppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AspLoginAppContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
