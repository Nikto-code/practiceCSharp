using Microsoft.EntityFrameworkCore;
using task1.Data;
using task1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite( builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IShoppingService, ShoppingService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shopping}/{action=Index}/{id?}");

app.Run();