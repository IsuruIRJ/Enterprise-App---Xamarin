using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise_App.Data
{
    public class UserCompany
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty(PropertyName = "bs")]
        public string BusinessStrategy { get; set; }
    }
}
