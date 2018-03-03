using Sitecore.XConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helixbase.Foundation.xConnect.Models.Facets.Interaction
{
    [Serializable]
    [FacetKey(FacetName)]
    public class GoogleApiFacet : Facet
    {
        public const string FacetName = "GoogleApiFacet";

        public string ZipCode { get; set; }

        public string Restaurant { get; set; }

        //public enum RestaurantType
        //{
        //    Unknown = 0,
        //    Italian,
        //    Indian,
        //    Chines
        //}
    }
}