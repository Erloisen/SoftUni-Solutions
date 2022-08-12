namespace CarDealer.DTOModels.ExportModels
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [JsonObject]
    public class CarsWithPartsList
    {
        [JsonProperty("car")]
        public CarExportModel Car { get; set; }

        [JsonProperty("parts")]
        public ICollection<PartExportModel> PartCars { get; set; }
    }
}
