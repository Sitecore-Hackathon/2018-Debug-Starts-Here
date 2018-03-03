using Helixbase.Foundation.xConnect.Models;
using Helixbase.Foundation.xConnect.Models.Facets.Interaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helixbase.Foundation.xConnect.Services
{
    public interface IXConnectService
    {
        void AddContact(string identifier, string firstName, string lastName);
        bool IdentifyContact(string identifier);
        void RegisterInteraction(string identifier, GoogleApiFacet googleApiFacet);
        ContactModel GetContact(string identifier);
    }
}
