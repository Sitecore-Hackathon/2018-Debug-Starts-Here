using Helixbase.Foundation.xConnect.Models.Facets.Interaction;
using Sitecore.XConnect;
using Sitecore.XConnect.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helixbase.Foundation.xConnect.Models.Facets
{
    public class GoogleApiModel
    {
        public static XdbModel Model { get; } = GoogleApiModel.BuildModel();

        private static XdbModel BuildModel()
        {
            var modelBuilder = new XdbModelBuilder("GoogleApiModel", new XdbModelVersion(1, 0));

            modelBuilder.ReferenceModel(Sitecore.XConnect.Collection.Model.CollectionModel.Model);
            modelBuilder.DefineFacet<Contact, GoogleApiFacet>(GoogleApiFacet.FacetName);
            modelBuilder.DefineEventType<CustomEvent>(true);

            return modelBuilder.BuildModel();
        }
    }
}