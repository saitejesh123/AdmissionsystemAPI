using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace hellosas.Controllers
{
    [Route("api/Testz")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("hey this is info message");
            _logger.LogWarning("Hey this is warning");
            _logger.LogError("This is an error message");
            _logger.LogCritical("This is a critical message");

            return Ok();
        }

    }
}
