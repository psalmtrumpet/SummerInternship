namespace SummerInternship.Model
{
    public class MultipleChoiceQuestion : Question
    {
        public List<string> Options { get; set; }
        public List<string> SelectedOptions { get; set; }
    }
}
