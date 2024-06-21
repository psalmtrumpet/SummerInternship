using Newtonsoft.Json;

namespace SummerInternship.Model
{
    public class EmployeePrograms
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Question> Questions { get; set; }
    }
}
