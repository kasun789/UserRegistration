using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models;
using UserRegistration.Repository;

namespace UserRegistration.Service
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IActionResult> InsertPersonInformationAsync(Person person)
        {
            await _personRepository.InsertPersonInformationAsync(person);
            return new OkResult();
        }
    }
}
