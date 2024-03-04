using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccess.Data;
using Portfolio.DataAccess.IRepository;
using Portfolio.DataAccess.Repository;

//Services
var builder = WebApplication.CreateBuilder(args);
//Controllers and Views
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//Database
builder.Services.AddDbContext<PortfolioDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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