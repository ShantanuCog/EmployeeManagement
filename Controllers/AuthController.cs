// Used to deal with the endpoint requests
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EmployeeManagement.Data;

namespace EmployeeManagement.Models;

[ApiController]    // Applying this class attribute '[]' first. This turns the 'AuthController' class to an API. Used to make it work like an endpoint.
[Route("api/[controller]")]    // Route method sets the foundation for the rest of the methods in the class below. Specifies the endpoint where the request will be received. Controller is a placeholder.
public class AuthController : ControllerBase    // the "Auth" in AuthController is used in the path of the endpoint
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _context;

    public AuthController(IConfiguration configuration, ApplicationDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    // register user
    [HttpPost("register")]      // send a POST request to https://localhost:5001/api/auth/register

    public IActionResult Register([FromBody] User user)
    {
        // Store this information to the database before confirming registration
        // SELECT * FROM Users WHERE Username = user.Username
        // CREATE USER user.Username
        // INSERT INTO Users (Username, Password) VALUES (user.Username, user.Password)
        /* 'user' contains all this:
        {
                "Email": "test@123.com",
                "Username": "test123",
                "Password": "safepassword"
            }
        */
        // Now, explicitly add each of the fields to the database
        var newUser = new User
        {
            Email = user.Email,
            Username = user.Username,
            Password = user.Password,
            DateCreated = DateTime.Now,
            DateUpdated = DateTime.Now
            // Role = user.UserRole
        };
        _context.User.Add(newUser); // similar to "git add"
        _context.SaveChanges();     // similar to "git commit"
        
        return Ok("User registered");
    }

    [HttpPost("login")]    // method: Login. type: IActionResult. attribute: login. Form of dependency injection
    public IActionResult Login([FromBody] User user)
    {
        // Normally, validate the user credentials from a DB
        if (user.Username == "admin" && user.Password == "password123")
        {
            var token = GenerateJwtToken(user.Username);
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }

    [HttpGet("logout")]    // 'HttpGet' method is encapsulating around 'Logout()'.
    // send a GET request to https://localhost:5001/api/auth/logout 
    public IActionResult Logout()
    {
        // Should have a function to clear the generated token.
        Console.WriteLine("We have logged out");
        return Ok("We have logged out");
    }

    // In Nodejs:
    // app.get("api/logout", async (req, res) => {
    //     res.Status(200).send.('We have logged out');
    //   }

    private string GenerateJwtToken(string username)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

// public class LoginModel
// {
//     public string Username { get; set; }
//     public string Password { get; set; }
// }
