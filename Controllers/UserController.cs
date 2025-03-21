using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    // List all users
    [HttpGet("list")]
    public IActionResult List()
    {
        return Ok("List of all users");
    }
}