
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyProject.Bussines;
using MyProject.Bussines.Customization.Identity;
using MyProject.DataAccess.Context;
using MyProject.Entity.Entities;
using System.Security.Claims;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
services.AddHttpContextAccessor();

services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost7122",
        policy => policy.WithOrigins("https://localhost:7122")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Add services to the container.

services.AddDbContext<MyProjectContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options => {
      options.EnableRetryOnFailure(); }
  ));


services.AddIdentity<AppUser, AppRole>(
    options =>
    {
        // Password settings
        options.Password.RequireDigit = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = true;
        options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+������������";

        // Other settings can be configured here
    }).AddEntityFrameworkStores<MyProjectContext>()
    .AddDefaultTokenProviders().AddErrorDescriber<CustomIdentityErrorDescriber>();

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true, //Olu�turulacak token de�erinin kimin da��tt���n� ifade etti�imiz alan -> www.myapi.com
        ValidateAudience = true, //Olu�turulacak token de�erini kimlerin/hangi originlerin/sitelerin kullanaca��n� belirledi�imiz de�erdir -> www.bilmemne.com
        ValidateLifetime = true, //Olu�turulan token d�erinin s�resini kontrol etti�imiz aland�r.
        ValidateIssuerSigningKey = true, //Olu�turulan token de�erinin uygulamam�za ait bir de�er oldu�unu kontrol etti�imiz aland�r. suciry key verisinin do�rulanmas�d�r

        ValidIssuer= builder.Configuration["Token:Issuer"],
        ValidAudience =builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),

        NameClaimType= ClaimTypes.Name,
        
        //Kullan�c�n�n ad�n� User.Identity.Name ile �ekmek istiyorsan, JWT i�indeki name claimine bak
        //User.Identity.Name propertysinden elde edebiliriz

    };
});

ServicesRegistration.AddServices(builder.Services);
builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseCors("AllowLocalhost7122");
app.UseAuthorization();

app.MapControllers();

app.Run();
