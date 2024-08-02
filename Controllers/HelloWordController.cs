using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWordController : ControllerBase
{
    IHelloWordService helloWordService;

    public HelloWordController(IHelloWordService helloWord)
    {
        helloWordService = helloWord;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(helloWordService.GetHelloWord());
    }
}