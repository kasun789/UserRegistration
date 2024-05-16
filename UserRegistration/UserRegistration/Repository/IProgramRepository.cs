using UserRegistration.Models;

namespace UserRegistration.Repository
{
    public interface IProgramRepository
    {
       Task<Programs> InsertProgramDetailAsync(Programs program);
    }
}
