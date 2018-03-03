using Helixbase.Foundation.xConnect.Models.Facets;
using Helixbase.Foundation.xConnect.Models.Facets.Interaction;
using Sitecore.Configuration;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Client.WebApi;
using Sitecore.XConnect.Collection.Model;
using Sitecore.XConnect.Schema;
using Sitecore.Xdb.Common.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Helixbase.Foundation.xConnect.Services
{
    public class XConnectService : IXConnectService
    {
        private readonly string XConnectUrl = Settings.GetSetting("xConnect.Url");
        private readonly string XConnectThumbprint = Settings.GetSetting("xConnect.Thumbprint");

        /// <summary>
        /// Add Contact
        /// </summary>
        /// <param name="identifier">Email</param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public void AddContact(string identifier, string firstName, string lastName)
        {
            using (XConnectClient client = GetClient())
            {
                var identifiers = new ContactIdentifier[]
                {
                    new ContactIdentifier(Constans.xConnectApiSource, identifier, ContactIdentifierType.Known )
                };
                var contact = new Contact(identifiers);

                var personalInfoFacet = new PersonalInformation
                {
                    FirstName = firstName,
                    LastName = lastName
                };
                client.SetFacet<PersonalInformation>(contact, PersonalInformation.DefaultFacetKey, personalInfoFacet);

                var emailFacet = new EmailAddressList(new EmailAddress(identifier, true), Constans.xConnectApiSource);
                client.SetFacet<EmailAddressList>(contact, EmailAddressList.DefaultFacetKey, emailFacet);

                client.AddContact(contact);
                client.Submit();
            }
        }

        /// <summary>
        /// Identify Contact
        /// </summary>
        /// <param name="identifier">Email</param>
        public bool IdentifyContact(string identifier)
        {
            using (XConnectClient client = GetClient())
            {
                var contactReference = new IdentifiedContactReference(Constans.xConnectApiSource, identifier);

                var contact = client.Get<Contact>(contactReference, new ContactExpandOptions(new string[] { PersonalInformation.DefaultFacetKey }));
                if (contact == null)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// Add Interaction
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="googleApiFacet"></param>
        public void RegisterInteraction(string identifier, GoogleApiFacet googleApiFacet)
        {
            using (XConnectClient client = GetClient())
            {
                var contactReference = new IdentifiedContactReference(Constans.xConnectApiSource, identifier);

                var contact = client.Get<Contact>(contactReference, new ContactExpandOptions(new string[] { PersonalInformation.DefaultFacetKey }));
                if (contact == null)
                    return;

                Interaction interaction = new Interaction(contactReference, InteractionInitiator.Contact,
                    channelId: new Guid(Constans.Offline_OtherEventChannelId), userAgent: Constans.UserAgent);

                // Add Custom GoogleApiFacet
                client.SetFacet<GoogleApiFacet>(new FacetReference(contact, GoogleApiFacet.FacetName), googleApiFacet);

                //// Adding some face information
                //IpInfo ipInfo = new IpInfo("127.0.0.1");
                //ipInfo.BusinessName = "Home";
                //client.SetFacet<IpInfo>(interaction, IpInfo.DefaultFacetKey, ipInfo);
                
                //WebVisit webVisit = new WebVisit();
                //webVisit.SiteName = "Offline";
                //client.SetFacet<WebVisit>(interaction, WebVisit.DefaultFacetKey, webVisit);

                Outcome outcome = new Outcome(new Guid(Constans.Offline_OtherEventChannelId), DateTime.UtcNow, "USD", 0)
                {
                    EngagementValue = 10,
                    Text = "Google Api Interaction"
                };
                interaction.Events.Add(outcome);

                client.AddInteraction(interaction);

                client.Submit();
            }
        }

        #region Private Method(s)
        private XConnectClient GetClient()
        {
            // Valid certificate thumbprint must be passed in
            CertificateWebRequestHandlerModifierOptions options =
                CertificateWebRequestHandlerModifierOptions.Parse($"StoreName=My;StoreLocation=LocalMachine;FindType=FindByThumbprint;FindValue={XConnectThumbprint}");

            // Optional timeout modifier
            var certificateModifier = new CertificateWebRequestHandlerModifier(options);

            List<IHttpClientModifier> clientModifiers = new List<IHttpClientModifier>();
            var timeoutClientModifier = new TimeoutHttpClientModifier(new TimeSpan(0, 0, 20));
            clientModifiers.Add(timeoutClientModifier);

            // This overload takes three client end points - collection, search, and configuration
            var collectionClient = new CollectionWebApiClient(new Uri($"{XConnectUrl.TrimEnd(new char['/'])}/odata"), clientModifiers, new[] { certificateModifier });
            var searchClient = new SearchWebApiClient(new Uri($"{XConnectUrl.TrimEnd(new char['/'])}/odata"), clientModifiers, new[] { certificateModifier });
            var configurationClient = new ConfigurationWebApiClient(new Uri($"{XConnectUrl.TrimEnd(new char['/'])}/configuration"), clientModifiers, new[] { certificateModifier });

            //Reference: https://sitecore.stackexchange.com/questions/8910/the-type-of-this-instance-does-not-correspond-to-any-type-in-the-model
            XdbModel[] models = { CollectionModel.Model, GoogleApiModel.Model };

            var xConnectClientConfiguration = new XConnectClientConfiguration(
                              new XdbRuntimeModel(models),
                              collectionClient,
                              searchClient,
                              configurationClient);

            try
            {
                xConnectClientConfiguration.Initialize();
            }
            catch (XdbModelConflictException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return new XConnectClient(xConnectClientConfiguration);
        }
        #endregion
    }
}