using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helixbase.Foundation.xConnect.Event
{
    public class LeadCaptured : Sitecore.XConnect.Event
    {
        public string ContactInfo { get; set; }

        public LeadCaptured(Guid definitionId, DateTime timestamp)
                : base(definitionId, timestamp)
        { }
    }
}