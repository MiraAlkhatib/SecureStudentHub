using Microsoft.EntityFrameworkCore;
using SecureStudentHub.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.Cookie.HttpOnly = true; // Prevents XSS stealing cookies
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Requires HTTPS
        options.Cookie.SameSite = SameSiteMode.Strict; // Prevents CSRF
    });


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SecureStudentHubDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"));

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