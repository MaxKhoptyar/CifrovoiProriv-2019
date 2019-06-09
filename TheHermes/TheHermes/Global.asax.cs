using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using CoreAuroraWeb.Models;

namespace TheHermes
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_End(object sender, EventArgs e)
        {
            //ScheduledTasksManager.Scheduler.Shutdown();
            //PreshiftExaminationQueueManager.Stop();
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            var ctrl = Request.RequestContext.RouteData.Values["controller"];
            string controller = (ctrl != null ? ctrl.ToString() : "");
            var act = Request.RequestContext.RouteData.Values["action"];
            string action = (act != null ? act.ToString() : "Index");

            if (Request.RequestContext.RouteData.Values["controller"] == null)
                return;
            var authTicket = GetAuthTicket();
            var serializer = new JavaScriptSerializer();

        }

        private FormsAuthenticationTicket GetAuthTicket()
        {
            var authCookie = Request.Cookies["TheHermes"];
            FormsAuthenticationTicket authTicket = null;
            if (authCookie != null && !String.IsNullOrEmpty(authCookie.Value))
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            return authTicket;


        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authTicket = GetAuthTicket();
            var serializer = new JavaScriptSerializer();
            if (authTicket != null)
            {
                var serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);
                var newUser = new CustomPrincipal(serializeModel.UserId.ToString())
                {
                    UserId = serializeModel.UserId,
                    Login = serializeModel.Login,
                    UserType = serializeModel.UserType,
                    Token = serializeModel.Token,
                };
                HttpContext.Current.User = newUser;
            }
        }

        protected void Application_BeginRequest()
        {

        }

        private void Session_Start(object sender, EventArgs e)
        {

            if ((HttpContext.Current != null) &&
                (HttpContext.Current.User != null) &&
                (HttpContext.Current.User.Identity.IsAuthenticated))
            {
                //var user = (CustomPrincipal)HttpContext.Current.User;
                //var login = user.Login;
            }
        }

        private void Session_End(object sender, EventArgs e)
        {

        }
    }
}
