namespace CarDealer.DTOModels.ImportModels
{
    using System;

    using Newtonsoft.Json;

    [JsonObject]
    public class CustomerInputModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
