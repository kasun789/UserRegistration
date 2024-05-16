using UserRegistration.Models;

namespace UserRegistration.Repository
{
    public interface IQuestionRepository
    {
        Task<Question> InsertQuestionAsync(Question question);
        Task<bool> DeleteQuestionAsync(string id);
        Task<Question> GetQuestionById(string id);
    }
}
