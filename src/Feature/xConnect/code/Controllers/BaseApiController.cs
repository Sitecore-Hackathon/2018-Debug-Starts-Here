using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace Helixbase.Feature.xConnect.Controllers
{
    public class BaseApiController : ApiController
    {
        private static readonly Regex _emailRegex = new Regex(@"\w+([-+.&#039;]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
        protected const string InternalServerErrorMessage = "Opps! something went wrong. Please try again.";
        protected const string InvalidInputParametersMessage = "You've provided invalid input parameters.";
        protected const string AlreadyIdentifiedMessage = "You are already identified in our system.";
        protected const string InvalidContactIdentifiedMessage = "You aren't identified in our system.";

        protected bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            if (_emailRegex.IsMatch(email))
                return true;

            return false;
        }
    }
}
