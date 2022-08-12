namespace CarDealer.DTOModels.ImportModels
{
    using Newtonsoft.Json;

    [JsonObject]
    public class SupplierInputModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isImporter")]
        public bool IsImporter { get; set; }
    }
}
