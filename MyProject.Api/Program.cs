using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyProject.Bussines;
using MyProject.Bussines.Customization.Identity;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.IdentitySeeder;
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
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
         .EnableSensitiveDataLogging()
);


services.AddIdentity<AppUser, AppRole>(
    options =>
    {
        // Password settings
        options.Password.RequireDigit = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = true;
        options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+çðýöþüÇÐÝÖÞÜ";

        // Other settings can be configured here
    }).AddEntityFrameworkStores<MyProjectContext>()
    .AddDefaultTokenProviders().AddErrorDescriber<CustomIdentityErrorDescriber>();

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true, //Oluþturulacak token deðerinin kimin daðýttýðýný ifade ettiðimiz alan -> www.myapi.com
        ValidateAudience = true, //Oluþturulacak token deðerini kimlerin/hangi originlerin/sitelerin kullanacaðýný belirlediðimiz deðerdir -> www.bilmemne.com
        ValidateLifetime = true, //Oluþturulan token dðerinin süresini kontrol ettiðimiz alandýr.
        ValidateIssuerSigningKey = true, //Oluþturulan token deðerinin uygulamamýza ait bir deðer olduðunu kontrol ettiðimiz alandýr. suciry key verisinin doðrulanmasýdýr

        ValidIssuer= builder.Configuration["Token:Issuer"],
        ValidAudience =builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),

        NameClaimType= ClaimTypes.Name,
        
        //Kullanýcýnýn adýný User.Identity.Name ile çekmek istiyorsan, JWT içindeki name claimine bak
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

using (var scope = app.Services.CreateScope())
{
    var scopedServices = scope.ServiceProvider;
    var dbContext = scopedServices.GetRequiredService<MyProjectContext>();

    await dbContext.Database.MigrateAsync();

    await SeedData.SeedRolesAndAdminAsync(scopedServices);
}

// Configure the HTTP request pipeline.     
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowLocalhost7122");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseExceptionHandler();
app.UseStatusCodePages();
app.Run();
