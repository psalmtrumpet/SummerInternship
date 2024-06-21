using SummerInternship.Model;

namespace SummerInternship.Dtos
{
    public class CandidateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string Residence { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
