namespace CarDealer.DTOModels.ExportModels
{
    using Newtonsoft.Json;

    [JsonObject]
    public class PartExportModel
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }
    }
}
