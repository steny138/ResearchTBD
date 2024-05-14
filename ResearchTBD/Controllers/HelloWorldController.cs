using Microsoft.AspNetCore.Mvc;

namespace ResearchTBD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await Task.CompletedTask;

        return Ok("Hello World.");
    }
}
