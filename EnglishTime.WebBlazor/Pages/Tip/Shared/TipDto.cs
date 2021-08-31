using System.Text.Json.Serialization;

namespace EnglishTime.WebBlazor.Pages.Tip.Shared
{
    public class TipDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("phrase")]
        public string Phrase { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("example")]
        public string Example { get; set; }
    }
}