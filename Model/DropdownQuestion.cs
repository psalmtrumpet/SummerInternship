namespace SummerInternship.Model
{
    public class DropdownQuestion : Question
    {
        public List<string> Options { get; set; }
        public string SelectedOption { get; set; }
    }
}
