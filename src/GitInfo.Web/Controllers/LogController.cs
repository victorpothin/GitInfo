using GitInfo.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GitInfo.Web.Controllers
{
    [ApiController]
    [Route("log")]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            _logger.LogInformation("ok logando");
            return Ok("ok");
        }

        [HttpPost]
        public ActionResult Post(object obj)
        {
            _logger.LogInformation(obj.ToString());
            return Ok("ok");
        }
    }
}