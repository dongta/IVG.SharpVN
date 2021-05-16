using IVG.Web.Mvc.EF;
using IVG.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IVG.Web.Mvc.Common;
using System.Web.Security;
using Newtonsoft.Json;
using System.IO;

namespace IVG.Web.Mvc.Controllers
{
    public class UserController : Controller
    {
        AppDbContext db = new AppDbContext();

        [HttpGet]
        public ActionResult Login(string returnUrl = "")
        {
            ViewBag.Errors = string.Empty;

            return View(new Login { ReturnUrl=returnUrl??"/"});
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login input)
        {
            var passMd5 = Helper.VerifyMD5.GetMd5Hash(input.Password);
            tbl_Users user = db.tbl_Users.FirstOrDefault(a => a.UserName == input.UserName && a.Password == passMd5 && a.UserType==input.UserType);
            if (user != null)
            {
                var UserJsonString = JsonConvert.SerializeObject(user, Formatting.Indented);
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now,
                DateTime.Now.AddHours(8), input.Remember=="on"?true:false, UserJsonString);
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (input.Remember=="on")
                    ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);
                return Redirect(input.ReturnUrl??"/");
                //return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Errors = "Thông tin đăng nhập không chính xác.";
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
        public ActionResult GetCaptChaImage()
        {
            int width = 100;
            int height = 36;
            var captchaCode = CaptchaHelper.GenerateCaptchaCode();
            var result = CaptchaHelper.GenerateCaptchaImage(width, height, captchaCode);
            System.Web.HttpContext.Current.Session.Add("CaptchaCode", result.CaptchaCode);
            Stream s = new MemoryStream(result.CaptchaByteData);
            return new FileStreamResult(s, "image/png");
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPassword input)
        {
            if (ModelState.IsValid)
            {
                var context = System.Web.HttpContext.Current;
                if (string.IsNullOrEmpty(input.Capcha) || !CaptchaHelper.ValidateCaptchaCode(input.Capcha, context))
                {
                    return View();
                }

                if (db.tbl_Users.Any(a => a.Email == input.Email))
                {
                    tbl_Users U = db.tbl_Users.FirstOrDefault(a => a.Email == input.Email);

                    var newPassword = System.Web.Security.Membership.GeneratePassword(6, 1);
                    var newMd5Pass = Helper.VerifyMD5.GetMd5Hash(newPassword);
                    U.Password = newMd5Pass;
                    db.SaveChanges();
                    ViewBag.Info = "Pass đã đổi thành "+newPassword;
                }
            }


            return View();
        }
    }
}
