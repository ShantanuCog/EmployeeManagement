using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    [HttpGet("{userid}")]   // get tasks by user id -> (api/tasks/123) returns feedback for user 123
    public IActionResult GetTasksByUserID(int userid)
    {
        return Ok("Tasks for user " + userid);
    }
    // List all tasks
    [HttpGet("list")]
    public IActionResult List()
    {
        return Ok("List of all tasks");
    }
}