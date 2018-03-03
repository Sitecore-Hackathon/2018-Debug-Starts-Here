using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helixbase.Foundation.xConnect.Models.Facets
{
    public class CustomEvent : Sitecore.XConnect.Event
    {
        public string ContactInfo { get; set; }

        public CustomEvent(Guid definitionId, DateTime timestamp)
                : base(definitionId, timestamp)
        { }
    }
}