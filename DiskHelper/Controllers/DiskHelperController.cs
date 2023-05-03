using DiskHelper.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiskHelper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiskHelperController : ControllerBase
    {
        private readonly ILogger<DiskHelperController> _logger;
        private readonly IDiskService _diskService;

        public DiskHelperController(ILogger<DiskHelperController> logger,
            IDiskService diskService)
        {
            _logger = logger;
            _diskService = diskService;
        }

        [HttpGet("DoDiskJob")]
        public ActionResult DoDiskJob() 
        {
            Console.WriteLine("Start job");
            _diskService.DoJob("D", 259);
            Console.WriteLine("Stop Job");
        
            return Ok();
        
        }
    }
}
