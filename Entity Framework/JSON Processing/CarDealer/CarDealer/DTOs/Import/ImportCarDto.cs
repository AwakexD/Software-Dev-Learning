using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Import
{
    public class ImportCarDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        [JsonProperty("traveledDistance")]
        public long TraveledDistance { get; set; }

        [JsonProperty("partsId")]
        public ICollection<int> CarParts { get; set; }
    }
}
