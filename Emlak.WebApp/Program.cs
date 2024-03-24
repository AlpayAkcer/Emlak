using Emlak.BusinessLayer.Extentions;
using Emlak.DataAccessLayer.Data;
using Emlak.DataAccessLayer.Extentions;
using Emlak.EntityLayer.Entities;
using Emlak.WebApp.Areas.Admin.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ServiceLayerExtention();
builder.Services.LoadDataLayerExtention();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddDbContext<EmlakDbContext>(conf => conf.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());
builder.Services.AddIdentity<UserAdmin, IdentityRole>().AddEntityFrameworkStores<EmlakDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false;

    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;

    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._+";
});

builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        ProgressBar = true,
        PositionClass = ToastPositions.TopRight,
        TimeOut = 5000
    })
    .AddRazorRuntimeCompilation();
// Sayfa Shift+F5 yapýldýðýnda Razor page yenilemesi için

builder.Services.AddSession();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    //config.Cookie = new CookieBuilder
    //{
    //    Name = "EmlakSistemi",
    //    HttpOnly = true,
    //    SameSite = SameSiteMode.Strict,
    //    SecurePolicy = CookieSecurePolicy.SameAsRequest //Canlýya aldýðýmýzda bu kýsmý Always yaparsak https olarak çalýþtýrabiliriz.
    //};
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7);
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
});

var app = builder.Build();

//Admin area içerisndeki seedIdentity metotunun tanýmlamasý
app.Seed().GetAwaiter().GetResult();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
