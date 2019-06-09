using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreAuroraWeb.Models;

namespace TheHermes.Controllers
{
    public class BaseController : Controller
    {
        protected new virtual CustomPrincipal User
        {
            get { return HttpContext.User as CustomPrincipal; }
        }
    }
}