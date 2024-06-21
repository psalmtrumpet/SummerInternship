namespace SummerInternship.Dtos
{
    public class YesNoDto : QuestionDto
    {
        public List<string> Options { get; set; } = new List<string> { "Yes", "No" };
        public YesNoDto()
        {
            Type = "YesNo";
        }
    }
}
