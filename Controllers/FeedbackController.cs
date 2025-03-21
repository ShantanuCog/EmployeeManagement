using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    [HttpGet("{userid}")]   // get feedback by user id -> (api/feedback/123) returns feedback for user 123
    public IActionResult GetFeedbackByUserID(int userid)
    {
        return Ok("Feedback for user " + userid);
    }
    // List all feedback - Admin use only
    [HttpGet("list")]
    public IActionResult List()
    {
        // check admin status after endpoint is requested
        // if (admin) return Ok("List of all feedback"), else return Unauthorized
        return Ok("List of all feedback");
    }
}