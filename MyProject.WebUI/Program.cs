using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Concrate;
using MyProject.DataAccess.Context;
using MyProject.Entity.Entities;
using MyProject.WebUI.Mapping;
using MyProject.WebUI.Models.ContactModel;
using MyProject.WebUI.Validations;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Map));

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<MyProjectContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options => {
      options.EnableRetryOnFailure();
  }
  ));


builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+çğıöşüÇĞİÖŞÜ";

    options.User.RequireUniqueEmail = true;
});


builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<MyProjectContext>()
    .AddDefaultTokenProviders();



builder.Services.AddScoped<IValidator<ContactUsViewModel>, ContactUsViewModelValidator>();

builder.Services.AddHttpClient();
builder.Services.AddHttpClient("ApiService1", client =>
{
    client.BaseAddress = new Uri("https://localhost:7177/api/v1/");
    client.Timeout = TimeSpan.FromMinutes(10);
    client.DefaultRequestHeaders
      .Accept
      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

});


builder.Services.AddHttpClient("admin", client =>
{
    client.BaseAddress = new Uri("https://localhost:7177/api/v1/admin/");
    client.Timeout = TimeSpan.FromMinutes(10);
    

});

builder.Services.AddHttpContextAccessor();   // IHttpContextAccessor


builder.Services.ConfigureApplicationCookie(opts => // birden fazla yönlerdirme hatasý aldým bunun ile çözüldü
{
    //Cookie settings
    opts.Cookie.HttpOnly = true;
    opts.ExpireTimeSpan = TimeSpan.FromMinutes(100);
    opts.AccessDeniedPath = new PathString("/Login/AccessDenied/");  //yetkisi olmayan sayfalarda gideceði path 
    opts.LoginPath = "/Login";
    opts.SlidingExpiration = true;
});

builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddSession(options => {
    options.Cookie.Name = ".DotNetCore.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(1);
    options.Cookie.IsEssential = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDistributedMemoryCache(); 


var app = builder.Build();


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
    pattern: "Admin/{controller=AdminHome}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
