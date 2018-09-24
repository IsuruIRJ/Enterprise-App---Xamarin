using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise_App.Data
{
    public class UserAddressGeo
    {
        [JsonProperty(PropertyName = "lat")]
        public double? Latitude { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public double? Longitude { get; set; }
    }
}
