namespace CarDealer.DTOModels.ExportModels
{
    using Newtonsoft.Json;

    [JsonObject]
    public class LocalSupplier
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("PartsCount")]
        public int PartsCount { get; set; }
    }
}
