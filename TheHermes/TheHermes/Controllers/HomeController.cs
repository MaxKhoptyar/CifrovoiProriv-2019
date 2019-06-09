using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreAuroraWeb.Structure;
using DbWorker;

namespace TheHermes.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            DbAccountWorker.AddStartData();
            DbOrganisationWorker.AddStartData();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}