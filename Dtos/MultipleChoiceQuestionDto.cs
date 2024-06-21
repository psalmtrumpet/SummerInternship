namespace SummerInternship.Dtos
{
    public class MultipleChoiceQuestionDto : QuestionDto
    {
        public List<string> Options { get; set; }
        public List<string> SelectedOptions { get; set; }
    }
}
