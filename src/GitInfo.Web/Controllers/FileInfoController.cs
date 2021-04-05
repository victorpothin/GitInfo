using GitInfo.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GitInfo.Web.Controllers
{
    [ApiController]
    [Route("FileInfo")]
    public class FileInfoController : ControllerBase
    {
        private readonly IFileInfoService fileInfoService;

        public FileInfoController(IFileInfoService fileInfoService)
        {
            this.fileInfoService = fileInfoService;
        }

        [HttpGet]
        public ActionResult Get(string route)
        {
            return Ok(this.fileInfoService.GetInfo(route));
        }
    }
}