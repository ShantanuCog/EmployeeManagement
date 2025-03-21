using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("api/[controller]")]
public class RotaController : ControllerBase
{
    [HttpGet("{userid}")]   // get rota by user id -> (api/rota/123) returns rota for user 123
    public IActionResult GetRotaByUserID(int userid)
    {
        return Ok("Rota for user " + userid);
    }
    // List all users
    [HttpGet("list")]
    public IActionResult List()
    {
        return Ok("List of whole rota");
    }
}