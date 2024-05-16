using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models;
using UserRegistration.Service;

namespace UserRegistration.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : Controller
    {
        private readonly PersonService _personService;
        private readonly QuestionAnswerService _questionAnswerService;

        public RegistrationController(PersonService personService, QuestionAnswerService questionAnswerService)
        {
            _personService = personService;
            _questionAnswerService = questionAnswerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int SumbitRegistration([FromBody] Person person, QuestionAnswer questionAnswer)
        {
            _personService.InsertPersonInformationAsync(person);
            _questionAnswerService.InsertQuestionAnswerAsync(questionAnswer);
            return 1;
        }
    }
}
