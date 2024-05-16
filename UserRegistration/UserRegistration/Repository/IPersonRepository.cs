using UserRegistration.Models;

namespace UserRegistration.Repository
{
    public interface IPersonRepository
    {
        Task<Person> InsertPersonInformationAsync(Person person);
    }
}
