using GitInfo.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GitInfo.Web.Controllers
{
    [ApiController]
    [Route("Log")]
    public class LogController : ControllerBase
    {
        public LogController()
        {
        }

        [HttpGet]
        public ActionResult Get(string route)
        {
            return Ok("ok");
        }
    }
}