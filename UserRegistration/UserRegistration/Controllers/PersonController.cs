using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models;
using UserRegistration.Service;

namespace UserRegistration.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly PersonService _personService;
        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public int InsertPersonInformationAsync([FromBody] Person person)
        {
            _personService.InsertPersonInformationAsync(person);
            return 1;
        }
    }
}
