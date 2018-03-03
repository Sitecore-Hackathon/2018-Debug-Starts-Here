using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helixbase.Foundation.xConnect.Models
{
    public class ContactInformation
    {
        public ContactInformation()
        {
            Created = DateTime.UtcNow;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
        public DateTime Created { get; set; }
    }
}