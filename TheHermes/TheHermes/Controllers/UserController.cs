using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreAuroraWeb.Structure;
using DbWorker;
using TheHermes.Models;
using TheHermesEntities;
using TheHermesEntities.Common;

namespace TheHermes.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult GetUserInfo()
        {
            var token = Request.GetToken();
            var user = DbAccountWorker.GetUserByToken(token);
            var personalData = DbUserWorker.GetUserInfo(user.Guid);
            var listOrganisation = DbOrganisationWorker.GetAllOrganisation();
            var model = new UserInfoModel();
            model.ListOrganisation = listOrganisation;

            if (personalData == null)
            {
                return View("UserInfo", model);
            }

            model.Age = personalData.Age;
            model.ChildrenCount = personalData.ChildrenCount;
            model.SelectedOrganisation = personalData.OrganisationGuid;
            return View("UserInfo", model);
        }

        public JsonResult UpdateUserInfo(UserInfoModel model)
        {
            var token = Request.GetToken();
            var user = DbAccountWorker.GetUserByToken(token);
            var userInfo = new UserInfo();
            userInfo.UserGuid = user.Guid;
            userInfo.Age = model.Age;
            userInfo.ChildrenCount = model.ChildrenCount;
            userInfo.OrganisationGuid = model.SelectedOrganisation;

            var updateResult = DbUserWorker.UpdateUserInfo(userInfo);
            if (updateResult == UpdateUserInfoResult.Success)
            {
                return Json(new { success = true, message = "Успех" });
            }
            return Json(new { success = false, message = "Ошибка" });
        }
    }
}