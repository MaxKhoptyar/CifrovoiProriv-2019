using System;
using System.Collections.Generic;
using System.Security.Principal;
using TheHermesEntities.Common;

namespace CoreAuroraWeb.Models
{
    public class CustomPrincipalSerializeModel
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public Guid UserGuid { get; set; }
        public Guid SessionGuid { get; set; }
        public RoleType UserType { get; set; }
        public string Token { get; set; }
    }

    public class CustomPrincipal : ICustomPrincipal
    {
        public bool IsInRole(string role)
        {
            var r = (RoleType)Enum.Parse(typeof(RoleType), role);
            if (r == UserType)
            {
                return true;
            }
            return false;
        }

        public IIdentity Identity { get; private set; }

        public CustomPrincipal(string userId)
        {
            Identity = new GenericIdentity(userId);
        }

        public int UserId { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
        public Guid UserGuid { get; set; }
        public RoleType UserType { get; set; }
        public bool IsUserType(RoleType userType)
        {
            if (UserType == userType)
            {
                return true;
            }
            return false;
        }
    }

    interface ICustomPrincipal : IPrincipal
    {
        int UserId { get; set; }
        string Login { get; set; }
        string Token { get; set; }
        Guid UserGuid { get; set; }
        RoleType UserType { get; set; }
    }
}
