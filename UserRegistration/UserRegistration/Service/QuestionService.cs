using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models;
using UserRegistration.Repository;

namespace UserRegistration.Service
{
    public class QuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository) {
            _questionRepository = questionRepository;
        }    

        public async Task<IActionResult> InsertQuestionAsync(Question question)
        {
            await _questionRepository.InsertQuestionAsync(question);
            return new OkResult();
        }

        public async Task<bool> DeleteQuestionAsync(string id)
        {
            await _questionRepository.DeleteQuestionAsync(id);
            return true;
        }

        public async Task<Question> GetQuestionById(string id)
        {
            Question question = await _questionRepository.GetQuestionById(id);
            return question;
        }
    }
}
