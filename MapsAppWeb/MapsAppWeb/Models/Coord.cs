using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapsAppWeb.Models
{
    public class Coord
    {
        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        public double Lat { get; set; } 

        [JsonProperty("lng", NullValueHandling = NullValueHandling.Ignore)]
        public double Lng { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }
}