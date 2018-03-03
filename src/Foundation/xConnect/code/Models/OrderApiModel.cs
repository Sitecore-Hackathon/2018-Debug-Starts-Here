using Sitecore.XConnect;
using Sitecore.XConnect.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helixbase.Foundation.xConnect.Models
{
    public class OrderApiModel
    {
        public static XdbModel Model { get; } = OrderApiModel.BuildModel();

        private static XdbModel BuildModel()
        {
            var builder = new XdbModelBuilder("OrderApiModel", new XdbModelVersion(1, 0));
            builder.ReferenceModel(Sitecore.XConnect.Collection.Model.CollectionModel.Model);
            // TOOD: Will add interaction
            builder.DefineFacet<Contact, OrderRegion>(OrderRegion.FacetName);
            //builder.DefineEventType<LeadCaptured>(true);

            return builder.BuildModel();
        }
    }
}