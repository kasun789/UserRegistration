using UserRegistration.Models;

namespace UserRegistration.Repository
{
    public interface IQuestionAnswerRepository
    {
        Task<QuestionAnswer> InsertAnswersForQuestion(QuestionAnswer questionAnswer);
    }
}
