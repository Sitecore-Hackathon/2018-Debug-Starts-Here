using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helixbase.Feature.xConnect.Models
{
    public class ContactRequestModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}