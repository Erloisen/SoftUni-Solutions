namespace CarDealer.DTOModels.ExportModels
{
    using System;

    using Newtonsoft.Json;

    [JsonObject]
    public class OrderedCustomers
    {
        public string Name { get; set; }

        public string BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
