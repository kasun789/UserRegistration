using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models;
using UserRegistration.Repository;

namespace UserRegistration.Service
{
    public class ProgramService
    {
        private readonly IProgramRepository _programRepository;

        public ProgramService(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public async Task<IActionResult> InsertProgramDetailAsync(Programs program)
        {
            await _programRepository.InsertProgramDetailAsync(program);
            return new OkResult();
        }
    }
}
