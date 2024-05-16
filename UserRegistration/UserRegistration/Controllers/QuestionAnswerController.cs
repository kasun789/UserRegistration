using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models;
using UserRegistration.Service;

namespace UserRegistration.Controllers
{
    [Route("api/questionAnswer")]
    [ApiController]
    public class QuestionAnswerController : Controller
    {
        private readonly QuestionAnswerService _questionAnswerServic;

        public QuestionAnswerController(QuestionAnswerService questionAnswerServic)
        {
            _questionAnswerServic = questionAnswerServic;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int InsertQuestionAnswer([FromBody] QuestionAnswer questionAnswer)
        {
            _questionAnswerServic.InsertQuestionAnswerAsync(questionAnswer);
            return 1;
        }
    }
}
