using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise_App.Data
{
    public class Comment
    {
        [JsonProperty(PropertyName = "PostId")]
        public int? PostId { get; set; }

        [JsonProperty(PropertyName = "Id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "Body")]
        public string Body { get; set; }
    }
}
