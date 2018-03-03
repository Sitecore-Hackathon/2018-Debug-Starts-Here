using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helixbase.Feature.xConnect.Models
{
    public class ContactInfo
    {
        public ContactInfo()
        {
            Created = DateTime.UtcNow;
        }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
    }
}