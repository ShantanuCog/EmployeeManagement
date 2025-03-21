using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using EmployeeManagement.Data;

// var builder = WebApplication.CreateBuilder(args);    // instance of web server
// var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);    // check for right encoding
class Program
{
    // create property of builder of type WebApplicationBuilder
    public static WebApplicationBuilder builder { get; set; }
    public static byte[] key { get; set; }

    public static void Main(string[] args)
    {
        // instantiate/create builder object
        builder = WebApplication.CreateBuilder(args);

        // Configure JWT Authentication. Using information from 'AppSetting.json'
        var jwtSettings = builder.Configuration.GetSection("Jwt");

        // instantiate.create key object
        key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

        // Add services. "importing" the controller details from 'AuthController.cs'
        builder.Services.AddControllers();
        // Add DbContext (Database Connection) to DI
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(    // change to 'UseSqlServer'
                builder.Configuration.GetConnectionString("DefaultConnection")));    // Refers to appsettings.json

        // Adds the authentication to the web server (using builder instance)
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })

        // creates the context for where the token is coming from (how the token is dealt with). Server creates the token after login
        // JWT stored in DB + sent to user. Compare the token in DB with user whenever it is requested DURING any logged in session. Username and password compared AT login
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

        // Build app
        var app = builder.Build();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

