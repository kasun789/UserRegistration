using UserRegistration.Models;
using UserRegistration.Repository;

namespace UserRegistration.Service
{
    public class QuestionAnswerService
    {
        private readonly IQuestionAnswerRepository _questionAnswerRepository;

        public QuestionAnswerService(IQuestionAnswerRepository questionAnswerRepository)
        {
            _questionAnswerRepository = questionAnswerRepository;
        }

        public int InsertQuestionAnswerAsync(QuestionAnswer questionAnswer)
        {
            _questionAnswerRepository.InsertAnswersForQuestion(questionAnswer);
            return 1;
        }
    }
}
