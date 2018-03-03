using Sitecore.XConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helixbase.Foundation.xConnect.Models
{
    [FacetKey(FacetName)]
    public class OrderRegion : Facet
    {
        public const string FacetName = "OrderRegion";

        public string Region { get; set; }
    }
}