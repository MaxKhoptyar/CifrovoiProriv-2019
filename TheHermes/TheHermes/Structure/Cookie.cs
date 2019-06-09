using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using CoreAuroraWeb.Models;
using TheHermesEntities;

namespace CoreAuroraWeb.Structure
{
    public static class Cookie
    {
        public static readonly string AuthCookieName =  "TheHermes";

        public static void Set(this HttpResponseBase response, UserModel loginInfo, CustomPrincipalSerializeModel serializeModel = null)
        {
            if (serializeModel == null)
            {
                var token = loginInfo.Token;
                var sessionGuid = Guid.NewGuid();
                
                serializeModel = new CustomPrincipalSerializeModel
                {
                    UserId = loginInfo.Id,
                    Login = loginInfo.Login,
                    Token = token,
                    //UserGuid = loginInfo.UserGuid,
                    UserType = loginInfo.UserType,
                    SessionGuid = sessionGuid,
                };
            }
            int timeout = 30;
            var serializer = new JavaScriptSerializer();
            var userData = serializer.Serialize(serializeModel);
            var ticket = new FormsAuthenticationTicket(1, serializeModel.UserId.ToString(), DateTime.Now, DateTime.Now.AddMinutes(timeout),true, userData);
            var encryptTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(AuthCookieName, encryptTicket);
            response.Cookies.Set(cookie);
        }

        static public CustomPrincipalSerializeModel Get(this HttpRequestBase request, string name)
        {
            var ticket = Get(request);
            if (!String.IsNullOrEmpty(ticket.UserData))
            {
                var serializer = new JavaScriptSerializer();
                var deSerializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(ticket.UserData);
                return deSerializeModel;
            }
            return null;
        }

        static public string GetToken(this HttpRequestBase request)
        {
            var ticket = Get(request);

            if (!String.IsNullOrEmpty(ticket.UserData))
            {
                var serializer = new JavaScriptSerializer();
                var deSerializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(ticket.UserData);
                return deSerializeModel.Token;
            }
            return "";
        }

        static public FormsAuthenticationTicket Get(this HttpRequestBase request)
        {
            var cook = request.Cookies.Get(AuthCookieName);
            if (cook != null && !String.IsNullOrEmpty(cook.Value))
            {
                return FormsAuthentication.Decrypt(cook.Value);
            }
            return new FormsAuthenticationTicket(AuthCookieName, false, 0);
        }
    }
}