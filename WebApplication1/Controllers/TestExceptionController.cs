using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

using System.Reflection;
using ExceptionAttribute.Attributes;
using ExceptionAttribute.IoC;

[ThrowExceptionHere(typeof(TestExceptionController))]
[ApiController]
[Route("[controller]")]
public class TestExceptionController : ControllerBase
{
    private readonly ExceptionAttributeModule module;

    private readonly ILogger<TestExceptionController> _logger;

    public TestExceptionController(ILogger<TestExceptionController> logger, 
        ExceptionAttributeModule module)
    {
        _logger = logger;
        this.module = module;
    }

    [HttpGet("[action]")]
    public IActionResult Throw()
    {
        var assembly = Assembly.GetExecutingAssembly();

        this.module.RandomException(assembly);
        
        return new OkObjectResult("Hello world");
    }
}