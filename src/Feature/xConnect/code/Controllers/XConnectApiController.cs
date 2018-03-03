using Helixbase.Feature.xConnect.Models;
using Helixbase.Foundation.xConnect.Models.Facets.Interaction;
using Helixbase.Foundation.xConnect.Services;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Helixbase.Feature.xConnect.Controllers
{
    public class XConnectApiController : BaseApiController
    {
        private readonly XConnectService _xConnectService;

        public XConnectApiController(XConnectService xConnectService)
        {
            _xConnectService = xConnectService;
        }

        public XConnectApiController() : this(new XConnectService())
        { }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage AddContact(ContactInfoRequestModel contactInfoRequestModel)
        {
            HttpResponseMessage response;

            try
            {
                if (contactInfoRequestModel == null || !IsValidEmail(contactInfoRequestModel.Email))
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, InvalidInputParametersMessage);
                    return response;
                }

                bool isContactIdentified = _xConnectService.IdentifyContact(contactInfoRequestModel.Email);
                if (isContactIdentified)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, AlreadyIdentifiedMessage);
                    return response;
                }

                _xConnectService.AddContact(contactInfoRequestModel.Email, contactInfoRequestModel.FirstName, contactInfoRequestModel.LastName);

                response = Request.CreateResponse(HttpStatusCode.Created);
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"Error in XConnectApiController.AddContact(): while adding contact with email: {contactInfoRequestModel?.Email}", ex, this);

                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerErrorMessage);
                return response;
            }
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage AddGoogleInteraction(GoogleInteractionRequestModel googleInteractionRequestModel)
        {
            HttpResponseMessage response;

            try
            {
                if (googleInteractionRequestModel == null || !IsValidEmail(googleInteractionRequestModel.Email))
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, InvalidInputParametersMessage);
                    return response;
                }

                bool isContactIdentified = _xConnectService.IdentifyContact(googleInteractionRequestModel.Email);
                if (!isContactIdentified)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, InvalidContactIdentifiedMessage);
                    return response;
                }

                GoogleApiFacet googleApiFacet = new GoogleApiFacet
                {
                    ZipCode = googleInteractionRequestModel.ZipCode,
                    Restaurant = googleInteractionRequestModel.RestaurantType
                };

                _xConnectService.RegisterInteraction(googleInteractionRequestModel.Email, googleApiFacet);

                response = Request.CreateResponse(HttpStatusCode.Created);
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"Error in XConnectApiController.AddGoogleInteraction(): while adding interaction for contact with email: {googleInteractionRequestModel?.Email}", ex, this);

                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerErrorMessage);
                return response;
            }
        }
    }
}