using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CoreAuroraWeb.Structure;
using DbWorker;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TheHermes.Models;
using TheHermesEntities;
using TheHermesEntities.Common;

namespace TheHermes.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            RemoveCookies();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var t = Request.GetToken();
            var result = DbAccountWorker.Authorization(model.Email, model.Password);
            if (result == null)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
            else
            {
                SetCookies(result);
                return RedirectToLocal(returnUrl);
            }
        }


        [AllowAnonymous]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = DbAccountWorker.CreateAccount(model.Email, model.Password);
                if (result.Succeeded)
                {
                    var resultUser = DbAccountWorker.Authorization(model.Email, model.Password);
                    SetCookies(resultUser);

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            return View(model);
        }

        private void SetCookies(UserModel info)
        {
            Response.Set(info);
        }

        private void RemoveCookies()
        {
            foreach (var cookie in Request.Cookies.AllKeys)
            {
                HttpCookie myCookie = new HttpCookie(cookie);
                myCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(myCookie);
            }
        }
       
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        public ActionResult Logout()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            FormsAuthentication.SignOut();
            Session.Abandon();
            RemoveCookies();
            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Helpers
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}