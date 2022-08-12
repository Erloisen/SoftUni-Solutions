namespace CarDealer.DTOModels.ImportModels
{
    using Newtonsoft.Json;

    [JsonObject]
    public class SalesImputModel
    {
        [JsonProperty("carId")]
        public int CarId { get; set; }

        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [JsonProperty("discount")]
        public decimal Discount { get; set; }


    }
}
