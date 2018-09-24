using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise_App.Data
{
    public class Post
    {
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Body")]
        public string Body { get; set; }
    }
}
