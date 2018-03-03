using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helixbase.Foundation.xConnect.Models
{
    public class GoogleInteractionModel
    {
        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }

        [JsonProperty("restaurant_type")]
        public string RestaurantType { get; set; }
    }
}