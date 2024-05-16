using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models;
using UserRegistration.Service;

namespace UserRegistration.Controllers
{
    [Route("api/program")]
    [ApiController]
    public class ProgramController : Controller
    {
        private readonly ProgramService _programService;
        public IActionResult Index()
        {
            return View();
        }

        public ProgramController(ProgramService programService)
        {
            _programService = programService;
        }

        [HttpPost]
        public int InsertProgramDetailAsync([FromBody] Programs program)
        {
            _programService.InsertProgramDetailAsync(program);

            return 1;
        }
    }
}
