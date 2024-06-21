using Newtonsoft.Json;

namespace SummerInternship.Model
{
    public class Question
    {
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Text { get; set; }
        public string Type { get; set; }
        //public List<string> Options { get; set; }
    }
}
