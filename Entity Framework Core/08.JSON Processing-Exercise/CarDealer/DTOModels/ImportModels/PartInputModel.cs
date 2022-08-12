namespace CarDealer.DTOModels.ImportModels
{
    using Newtonsoft.Json;

    [JsonObject]
    public class PartInputModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("supplierId")]
        public int SupplierId { get; set; }
    }
}
