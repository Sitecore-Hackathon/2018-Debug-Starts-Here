using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using Sitecore.ExperienceForms.Processing.Actions.Models;
using Sitecore.Links;
using Sitecore.Text;
using System;
using System.Linq;

namespace Helixbase.Feature.ExperienceForms.Controllers
{
    public class UserController : SubmitActionBase<RedirectActionData>
    {
        public UserController(ISubmitActionData submitActionData) : base(submitActionData)
        {
        }
        protected override bool Execute(RedirectActionData data, FormSubmitContext formSubmitContext)
        {
            Assert.ArgumentNotNull(formSubmitContext, "formSubmitContext");
            if (data == null || !(data.ReferenceId != Guid.Empty))
                return false;
            var item = Sitecore.Context.Database.GetItem(new ID(data.ReferenceId));
            if (item == null)
                return false;

            var email = string.Empty;
            var firstName = string.Empty;
            var lastName = string.Empty;
            var postedFormData = formSubmitContext.Fields;
            var field = postedFormData.FirstOrDefault(f => f.Name.Equals("Email"));
            if (field != null)
            {
                var property = field.GetType().GetProperty("Value");
                var postedEmail = property.GetValue(field);
                email = postedEmail != null ? postedEmail.ToString() : string.Empty;
            }
            field = postedFormData.FirstOrDefault(f => f.Name.Equals("First Name"));
            if (field != null)
            {
                var property = field.GetType().GetProperty("Value");
                var postedField = property.GetValue(field);
                firstName = postedField != null ? postedField.ToString() : string.Empty;
            }
            field = postedFormData.FirstOrDefault(f => f.Name.Equals("Last Name"));
            if (field != null)
            {
                var property = field.GetType().GetProperty("Value");
                var postedField = property.GetValue(field);
                lastName = postedField != null ? postedField.ToString() : string.Empty;
            }
           
            formSubmitContext.Abort();
            return true;
        }
    }
}