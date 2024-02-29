using LevchenkoVladWebApplication.Data;
using Microsoft.EntityFrameworkCore;

//Services
var builder = WebApplication.CreateBuilder(args);
//Controllers and Views
builder.Services.AddControllersWithViews();
//Database
builder.Services.AddDbContext<PortfolioDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Building everything
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

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