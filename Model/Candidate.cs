using Newtonsoft.Json;

namespace SummerInternship.Model
{
    public class Candidate
    {
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string Residence { get; set; }
        public List<Answers> Answers { get; set; }
    }
}
