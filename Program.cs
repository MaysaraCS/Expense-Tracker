using Expense_Tracker.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // ✅ Add this

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependency Injection (DI)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DevConnection"),
        new MySqlServerVersion(new Version(8, 0, 0)) // ✅ MySQL version
    )
);


//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JFaF1cX2hIfkx0QHxbf1x1ZFxMZFxbQHJPMyBoS35Rc0RjWHdeeXBVQmRcVEd1VEFc");
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
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();

// EF Core commands to use:
// Add-Migration "InitialCreate"
// Update-Database
