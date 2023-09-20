using Microsoft.AspNetCore.Mvc;

namespace Logger.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    [HttpGet("/hello")]
    public IActionResult Hello()
    {
        _logger.LogError("New request!");

        return Ok(new
        {
            Message = "Hello World!"
        });
    }
}