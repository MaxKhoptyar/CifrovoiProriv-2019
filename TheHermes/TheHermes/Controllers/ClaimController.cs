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
    public class ClaimController : BaseController
    {
        public ActionResult FormForCreateClaim()
        {
            var model = new FormForCreateClaimModel();
            var listClaimType = DbClaimWorker.GetClaimTypes();
            model.ListClaimType = listClaimType;
            return View("FormForCreateClaim", model);
        }

        public ActionResult CreateClaim(CreateClaimModel createClaimModel)
        {
            var token = Request.GetToken();
            var user = DbAccountWorker.GetUserByToken(token);
            var claim = new Claim();
            claim.UserGuid = user.Guid;
            claim.TypeId = createClaimModel.SelectedClaimType;
            claim.UserGuid = user.Guid;
            claim.AccompanyingMessage = createClaimModel.AccompanyingMessage;

            var result = DbClaimWorker.CreateClaim(claim);

            if (result == CreateClaimResult.Success)
            {
                return Json(new { success = true, isMerge = false, message = result.DescriptionAttr() });
            }
            if (result == CreateClaimResult.Merge)
            {
                return Json(new { success = true, isMerge = true, message = result.DescriptionAttr() });
            }
            return Json(new { success = false, message = result.DescriptionAttr() });
        }

        public JsonResult CollaborateClaim(CollaborateClaimModel collaborateClaimModel)
        {
            var token = Request.GetToken();
            var user = DbAccountWorker.GetUserByToken(token);
            var result = DbClaimWorker.CollaborateClaim(user, collaborateClaimModel.ClaimId, collaborateClaimModel.AccompanyingMessage);

            if (result == CreateClaimResult.Success)
            {
                return Json(new { success = true, isMerge = false, message = result.DescriptionAttr() });
            }
            if (result == CreateClaimResult.Merge)
            {
                return Json(new { success = true, isMerge = true, message = result.DescriptionAttr() });
            }
            return Json(new { success = false, message = result.DescriptionAttr() });
        }

        public ActionResult CollaborateClaimAction(int claimId)
        {
            var claim = DbClaimWorker.GetClaim(claimId);
            var model = new CollaborateClaimInfoModel();
            model.ClaimInfo = claim;
            return View("CollaborateClaim", model);
        }

        public ActionResult AdministrationClaim()
        {
            var token = Request.GetToken();
            var role = DbAccountWorker.GetRoleByToken(token);
            if (role == RoleType.Administrator)
            {
                var claimInfo = DbClaimWorker.GetClaimForAdmin();
                var model = new AdministrationClaimModel();
                model.ClaimInfo = claimInfo;
                return View("AdministrationClaim", model);
            }
            else
            {
                return View("AccessDenied");
            }
        }

        public ActionResult WorkWithClaim(int claimId)
        {
            var token = Request.GetToken();
            var role = DbAccountWorker.GetRoleByToken(token);
            if (role == RoleType.Administrator)
            {
                var claimInfo = DbClaimWorker.GetClaimForWork(claimId);
                if (claimInfo == null)
                {
                    return View("Error");
                }
                var model = new ClaimForWorkModel();
                model.ClaimInfo = claimInfo;
                return View("ClaimForWorkClaim", model);
            }
            else
            {
                return View("AccessDenied");
            }
        }
        public ActionResult OpenRatingClaim(int claimId)
        {
            var token = Request.GetToken();
            var role = DbAccountWorker.GetRoleByToken(token);
            if (role == RoleType.Administrator)
            {
                DbClaimWorker.OpenRatingClaim(claimId);
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
        public ActionResult CloseRatingClaim(int claimId)
        {
            var token = Request.GetToken();
            var role = DbAccountWorker.GetRoleByToken(token);
            if (role == RoleType.Administrator)
            {
                DbClaimWorker.CloseRatingClaim(claimId);
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        public ActionResult MarkedClaims()
        {
            var token = Request.GetToken();
            var user = DbAccountWorker.GetUserByToken(token);
            var dbRole = DbAccountWorker.GetRoleByUser(user);
            if (dbRole == RoleType.User)
            {
                var notificationUserModel = new MarkedClaimsUserModel();
                var claimsInfo = DbClaimWorker.GetMarkedClaimsByUser(user);
                notificationUserModel.ClaimInfo = claimsInfo;
                return View("MarkedClaimsUser", notificationUserModel);
            }
            else
            {
                var notificationOrganisationModel = new MarkedClaimsOrganisationModel();
                var claimsInfo = DbClaimWorker.GetMarkedClaimsByOrganisation(user);
                notificationOrganisationModel.ClaimInfo = claimsInfo;
                return View("MarkedClaimsOrganisation", notificationOrganisationModel);
            }
        }

        public ActionResult RatingClaimAction(int claimId)
        {
            var claim = DbClaimWorker.GetClaim(claimId);
            var model = new RatingClaimFormModel();
            model.ClaimInfo = claim;
            model.Rating = DbClaimWorker.GetClaimRatings();

            return View("RatingClaim", model);
        }

        public JsonResult RatingClaim(RatingClaimModel ratingClaimModel)
        {
            var token = Request.GetToken();
            var user = DbAccountWorker.GetUserByToken(token);
            var result = DbClaimWorker.CreateRating(user, ratingClaimModel.ClaimId, ratingClaimModel.Rating, ratingClaimModel.Message);
            if (result == CreateRatingResult.Success)
            {
                return Json(new { success = true, message = result.DescriptionAttr() });
            }
            return Json(new { success = false, message = result.DescriptionAttr() });
        }

        public ActionResult Statistic()
        {
            var statistic = DbClaimWorker.GetStatistic();

            var model = new StatisticModel();
            model.Statistic = statistic;

            return View("Statistic", model);
        }
    }
}