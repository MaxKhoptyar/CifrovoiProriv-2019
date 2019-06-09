using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreAuroraWeb.Structure;
using DbWorker;
using Extentions;
using TheHermes.Models;
using TheHermesEntities;
using TheHermesEntities.Common;

namespace TheHermes.Controllers
{
    public class NotificationController : BaseController
    {
        public ActionResult Index()
        {
            var token = Request.GetToken();
            var user = DbAccountWorker.GetUserByToken(token);
            var dbRole = DbAccountWorker.GetRoleByUser(user);
            if (dbRole == RoleType.User)
            {
                var notificationUserModel = new NotificationUserModel();
                var notification = DbNotififcationWorker.GetNotification(user);
                var claims = DbClaimWorker.GetClaims(notification);
                notificationUserModel.Notification = notification;
                notificationUserModel.Claims = claims;
                return View("NotificationUserModel", notificationUserModel);
            }
            else
            {
                var notificationOrganisationModel = new NotificationOrganisationModel();
                var notification = DbNotififcationWorker.GetNotification(user);
                var claims = DbClaimWorker.GetClaims(notification);
                notificationOrganisationModel.Notification = notification;
                notificationOrganisationModel.Claims = claims;
                return View("NotificationOrganisation", notificationOrganisationModel);
            }
        }

        public JsonResult GetNotification()
        {
            var token = Request.GetToken();
            var user = DbAccountWorker.GetUserByToken(token);
            var notifications = DbNotififcationWorker.GetNotificationCount(user);
            return Json(new { success = true, count = notifications });
        }

        //public ActionResult FormForAnswerClaim()
        //{
        //    return View();
        //}
    }
}