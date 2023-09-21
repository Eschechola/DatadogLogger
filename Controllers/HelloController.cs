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
        try{
            throw new Exception("Test exception!!");
        }catch(Exception e){
            _logger.LogError(e.Message);
        }

        return Ok(new
        {
            Message = "Hello World!"
        });
    }
}