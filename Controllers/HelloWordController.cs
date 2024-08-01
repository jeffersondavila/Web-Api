using Microsoft.AspNetCore.Mvc;

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

    public IActionResult Get()
    {
        return Ok(helloWordService.GetHelloWord());
    }
}