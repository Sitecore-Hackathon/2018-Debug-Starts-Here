using Helixbase.Feature.xConnect.Models;
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
        public HttpResponseMessage AddContact(ContactInfo contactInfo)
        {
            HttpResponseMessage response;

            try
            {
                if (contactInfo == null || !IsValidEmail(contactInfo.Email))
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, InvalidInputParametersMessage);
                    return response;
                }

                bool isContactIdentified = _xConnectService.IdentifyContact(contactInfo.Email);
                if (isContactIdentified)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, AlreadyIdentifiedMessage);
                    return response;
                }

                _xConnectService.AddContact(contactInfo.Email, contactInfo.FirstName, contactInfo.LastName);

                response = Request.CreateResponse(HttpStatusCode.Created);
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"Error in XConnectApiController.AddContact(): while adding contact with email: {contactInfo?.Email}", ex, this);

                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerErrorMessage);
                return response;
            }
        }


    }
}