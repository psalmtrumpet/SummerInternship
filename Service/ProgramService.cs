using Mapster;
using SummerInternship.Dtos;
using SummerInternship.Model;
using SummerInternship.Repository;

namespace SummerInternship.Service
{
    public class ProgramService
    {
        private readonly ICosmosRepository<EmployeePrograms> _programRepository;
        private readonly ICosmosRepository<Candidate> _cadidaterepository;
        public ProgramService(ICosmosRepository<EmployeePrograms> programRepository, ICosmosRepository<Candidate> cadidaterepository)
        {
            _programRepository = programRepository;
            _cadidaterepository = cadidaterepository;
        }
        public async Task<Candidate> Submitform(CandidateDto payload)
        {
            var mappedData = payload.Adapt<Candidate>();
            mappedData.Id = Guid.NewGuid().ToString();

            return await _cadidaterepository.CreateItemAsync(mappedData, mappedData.Id);
        }
        public async Task<EmployeePrograms> CreateProgram(EmployeeProgramDto program)
        {
            var mappedData = program.Adapt<EmployeePrograms>();


            foreach (var question in mappedData.Questions)
            {

                switch (question.Type)
                {
                    case "Dropdown":
                        var map = question.Adapt<DropdownQuestion>();
                        break;
                    case "Numeric":
                        var numericQuestion = (NumberQuestion)question;
                        break;

                    case "Date":
                        var dateQuestion = (DateQuestion)question;
                        break;
                    case "YesNo":
                        var yesNoQuestion = (YesNoQuestion)question;
                        break;
                    case "MultipleChoice":
                        var multipleChoiceQuestion = (MultipleChoiceQuestion)question;
                        break;
                    case "Paragraph":
                        var paragraphQuestion = question.Adapt<ParagraphQuestion>();
                        break;
                    default:
                        break;
                }
            }
            return await _programRepository.CreateItemAsync(mappedData, mappedData.Id);
        }

        public async Task<EmployeePrograms> GetProgramById(string id)
        {
            return await _programRepository.GetItemAsync(id, id);
        }

        public async Task<IEnumerable<EmployeePrograms>> GetAllPrograms()
        {
            return await _programRepository.GetItemsAsync("SELECT * FROM c");
        }

        public async Task<EmployeePrograms> UpdateProgram(string id, EmployeeProgramDto program)
        {
            var mappedData = program.Adapt<EmployeePrograms>();
            var existingProgram = await _programRepository.GetItemAsync(id, id);
            if (existingProgram == null)
            {
                return null;
            }
            existingProgram.Title = mappedData.Title;
            existingProgram.Description = mappedData.Description;
            existingProgram.Questions = mappedData.Questions;
            return await _programRepository.UpdateItemAsync(id, existingProgram, id);
        }

        public async Task DeleteProgram(string id)
        {
            await _programRepository.DeleteItemAsync(id, id);
        }
    }
}
