using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models;
using UserRegistration.Service;

namespace UserRegistration.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController : Controller
    {
        public readonly QuestionService _questionService;

        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int InsertQuestionAsync([FromBody] Question question)
        {
            _questionService.InsertQuestionAsync(question);
            return 1;
        }

        [HttpDelete("/id")]
        public bool DeleteQuestion(string id)
        {
            _questionService.DeleteQuestionAsync(id);
            return true;
        }

        [HttpGet("/id")]
        public  Task<Question> GetQuestionById(string id)
        {
            Task<Question> question =  _questionService.GetQuestionById(id);
            return question;
        }
    }
}
