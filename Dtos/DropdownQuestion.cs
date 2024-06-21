namespace SummerInternship.Dtos
{
    public class DropdownQuestionDto : QuestionDto
    {
        public List<string> Options { get; set; }
        public string SelectedOption { get; set; }
    }
}
