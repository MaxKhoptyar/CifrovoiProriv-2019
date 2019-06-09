using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreAuroraWeb.Models;

namespace TheHermes.Views
{
    public abstract class BaseViewPage : WebViewPage
    {
        public virtual new CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }
}