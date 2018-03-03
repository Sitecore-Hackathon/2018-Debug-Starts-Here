using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helixbase.Feature.xConnect.Models
{
    public class GoogleInteractionRequestModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }

        [JsonProperty("restaurant_type")]
        public string RestaurantType { get; set; }
    }
}