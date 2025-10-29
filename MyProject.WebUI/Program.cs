using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Concrate;
using MyProject.DataAccess.Context;
using MyProject.Entity.Entities;
using MyProject.WebUI.Mapping;
using MyProject.WebUI.Models.ContactModel;
using MyProject.WebUI.Validations;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Map));

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSwaggerGen();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(120); // oturum süresi
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddDbContext<MyProjectContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options => {
      options.EnableRetryOnFailure();
  }
  ));


builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+çðýöþüÇÐÝÖÞÜ";

    options.User.RequireUniqueEmail = true;
});

// 2. Sonra Identity eklenir
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<MyProjectContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IValidator<ContactUsViewModel>, ContactUsViewModelValidator>();


// "ApiService1" adýnda bir named HttpClient örneði
builder.Services.AddHttpClient("ApiService1", client =>
{
    client.BaseAddress = new Uri("https://localhost:7177/api/v1");
    client.Timeout = TimeSpan.FromMinutes(10);
    client.DefaultRequestHeaders.Clear();
    
});
builder.Services.AddHttpClient("admin", client =>
{
    client.BaseAddress = new Uri("https://localhost:7177/api/Admin");
    client.Timeout = TimeSpan.FromMinutes(10);
    client.DefaultRequestHeaders.Clear();
});

builder.Services.AddHttpContextAccessor();   // IHttpContextAccessor
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.LogoutPath = "/Login/Logout";
    });
builder.Services.AddSession();


var app = builder.Build();
// Middleware’lere session'ý ekle
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();


app.MapAreaControllerRoute(
    name: "MyAreaAdmin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
