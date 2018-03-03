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

        public List<GoogleApiFacetInfo> GoogleApiFacetInfoList { get; set; } = new List<GoogleApiFacetInfo>();
    }

    public class GoogleApiFacetInfo
    {
        public string ZipCode { get; set; }

        public string RestaurantType { get; set; }
    }
}