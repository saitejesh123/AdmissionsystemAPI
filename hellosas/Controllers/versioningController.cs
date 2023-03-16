using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hellosas.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/sample")]


    
        public class versioningModel : ControllerBase
        {
            [HttpGet]
            public IActionResult Get()
            {
                return new OkObjectResult("Using versioning");
            }

        }
}

