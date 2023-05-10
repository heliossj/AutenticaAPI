using AutenticaAPI.Data;
using AutenticaAPI.Models;
using AutenticaAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//inicia o serviço de conexão
string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

//var connectionString = builder.Configuration.GetConnectionString("Default");
//builder.Services.AddDbContext<AppDbContext>(opts =>
//{
//    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
//});

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services
    .AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(Path.GetTempPath()));

builder.Services.AddAutoMapper
    (AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

var build = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
IConfigurationRoot configuration = build.Build();
var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);

builder.Services.AddAuthentication(opts =>
{
    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opts =>
{
    opts.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();