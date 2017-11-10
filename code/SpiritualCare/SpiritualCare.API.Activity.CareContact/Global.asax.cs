using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SpiritualCare.API.Activity.CareContact
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            var currentRequest = HttpContext.Current.Request;
            var currentResponse = HttpContext.Current.Response;
            var currentApplication = HttpContext.Current.ApplicationInstance;

            var currentRequestOrigin = currentRequest.Headers["Origin"];

            if (currentRequest.HttpMethod.ToLower() == "options" && currentRequestOrigin != null && originAllowed(currentRequestOrigin))
            {
                currentResponse.StatusCode = 200;
                currentResponse.Flush(); // Sends all currently buffered output to the client.
                currentApplication.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
            }
        }

        private bool originAllowed(string currentRequestOrigin)
        {
            currentRequestOrigin = currentRequestOrigin.ToLower().Trim();

            return SpiritualCare.API.Activity.CareContact.Properties.Settings.Default.AllowOrigins.IndexOf(currentRequestOrigin) >= 0;

        }
    }
}
