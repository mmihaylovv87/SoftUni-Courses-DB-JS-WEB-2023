namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ImportCarDto
    {
        [JsonProperty("make")]
        public string Make { get; set; } = null!;

        [JsonProperty("model")]
        public string Model { get; set; } = null!;

        [JsonProperty("travelledDistance")]
        public long TravelledDistance { get; set; }

        [JsonProperty("partsId")]
        public ICollection<int> PartsId { get; set; } = null!;
    }
}