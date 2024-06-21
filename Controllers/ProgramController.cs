using Microsoft.AspNetCore.Mvc;
using SummerInternship.Dtos;
using SummerInternship.Service;

namespace SummerInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly ProgramService _programService;


        public ProgramController(ProgramService programService)
        {
            _programService = programService;
        }
        [HttpPost]
        public async Task<ActionResult> CreateProgram(EmployeeProgramDto program)
        {
            var createdProgram = await _programService.CreateProgram(program);
            return Ok(createdProgram);
        }



        [HttpPost("submitform")]
        public async Task<ActionResult> SubmitForm(CandidateDto program)
        {
            var submittedform = await _programService.Submitform(program);
            return Ok(submittedform);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllQuestion()
        {
            var allProgram = await _programService.GetAllPrograms();
            return Ok(allProgram);
        }

        [HttpPut]
        public async Task<ActionResult> EditProgram(string id, EmployeeProgramDto program)
        {
            var Program = await _programService.UpdateProgram(id, program);
            return Ok(Program);
        }
    }
}
