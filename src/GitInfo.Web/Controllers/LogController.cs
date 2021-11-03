using GitInfo.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GitInfo.Web.Controllers
{
    [ApiController]
    [Route("log")]
    public class LogController : ControllerBase
    {
        public LogController()
        {
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("ok");
        }
    }
}