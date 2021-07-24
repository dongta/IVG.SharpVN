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
    [Authorize]
    public class UserController : Controller
    {
        AppDbContext db = new AppDbContext();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl = "")
        {
            ViewBag.Errors = string.Empty;
            var loginInfo = new Login
            {
                ReturnUrl = returnUrl ?? "/"
            };
            //var userCoookie = HttpContext.Request.Cookies["login"];
            //if (userCoookie != null)
            //{
            //    loginInfo.UserName = userCoookie["username"];
            //    //loginInfo.Password = userCoookie["password"];
            //    loginInfo.UserType = string.IsNullOrEmpty(userCoookie["usertype"]) ? AppEnum.Role.Dealer : (AppEnum.Role)Enum.Parse(typeof(AppEnum.Role), userCoookie["usertype"], true);
            //}

            return View(loginInfo);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login input)
        {
            string errorMessages = string.Empty;
            if (ModelState.IsValid)
            {
                var passMd5 = Helper.VerifyMD5.GetMd5Hash(input.Password);
                tbl_Users user = db.tbl_Users.FirstOrDefault(a => a.UserName == input.UserName && a.Password == passMd5);
                var role = db.tbl_Roles.FirstOrDefault(a => a.Role == input.UserType.ToString());
                if (user != null && db.tbl_UserRoles.Any(a => a.UserID == user.ID && a.RoleID == role.ID))
                {
                    int timeout = 2880;//2 ngày
                    input.Remember = (input.Remember ?? string.Empty).ToLower();
                    var rememberMe = (input.Remember == "on" || input.Remember == "true") ? true : false;

                    timeout = rememberMe ? 525600 : timeout; // Timeout in minutes, 525600 = 365 days.
                    {
                        //form authentication check cookie để login
                        var ticket = new FormsAuthenticationTicket(user.UserName, rememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true; 
                        Response.Cookies.Add(cookie);
                    }
                    {//set các cookie,session tiện cho check dữ liệu
                        HttpCookie roleCkie = new HttpCookie("role");
                        roleCkie["rolename"] = input.UserType.ToString();
                        roleCkie.Expires = DateTime.Now.AddMinutes(timeout);
                        HttpContext.Response.SetCookie(roleCkie);

                        HttpCookie usercookie = new HttpCookie("user");
                        usercookie["id"] = user.ID.ToString();
                        usercookie["name"] = user.DisplayName;
                        usercookie.Expires = DateTime.Now.AddMinutes(timeout);
                        HttpContext.Response.SetCookie(usercookie);

                        Session["user"] = user;
                    }
                    return Redirect(input.ReturnUrl ?? "/");
                }
                else
                {
                    errorMessages = "Login failed.";
                }
            }
            else
            {
                errorMessages = string.Join(" <br /> ", this.ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            }
            ViewBag.Errors = errorMessages;
            return View(input);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login1(Login input)
        {
            string errorMessages = string.Empty;
            if (ModelState.IsValid)
            {
                var passMd5 = Helper.VerifyMD5.GetMd5Hash(input.Password);
                tbl_Users user = db.tbl_Users.FirstOrDefault(a => a.UserName == input.UserName && a.Password == passMd5);
                var role = db.tbl_Roles.FirstOrDefault(a => a.Role == input.UserType.ToString());
                if (user != null && db.tbl_UserRoles.Any(a => a.UserID == user.ID && a.RoleID == role.ID))
                {
                    var UserJsonString = role.Role;//JsonConvert.SerializeObject(role, Formatting.Indented);
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    FormsAuthenticationTicket tkt;
                    string cookiestr;
                    HttpCookie ck;
                    tkt = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now,
                    DateTime.Now.AddHours(8), input.Remember == "on" ? true : false, UserJsonString);
                    cookiestr = FormsAuthentication.Encrypt(tkt);
                    ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);

                    HttpCookie roleCkie = new HttpCookie("role");
                    roleCkie["rolename"] = input.UserType.ToString();
                    roleCkie.Expires = DateTime.Now.AddMonths(1);
                    HttpContext.Response.SetCookie(roleCkie);

                    HttpCookie usercookie = new HttpCookie("user");
                    usercookie["id"] = user.ID.ToString();
                    usercookie["name"] = user.DisplayName;
                    usercookie.Expires = DateTime.Now.AddMonths(1);
                    HttpContext.Response.SetCookie(usercookie);

                    Session["user"] = user;

                    if (input.Remember == "on" || input.Remember == "true")
                    {
                        ck.Expires = tkt.Expiration;
                        HttpCookie loginRemember = new HttpCookie("login");
                        loginRemember["username"] = input.UserName;
                        loginRemember["password"] = input.Password;
                        loginRemember["usertype"] = input.UserType.ToString();
                        loginRemember.Expires = DateTime.Now.AddMonths(1);
                        HttpContext.Response.SetCookie(loginRemember);
                    }
                    ck.Path = FormsAuthentication.FormsCookiePath;
                    Response.Cookies.Add(ck);
                    return Redirect(input.ReturnUrl ?? "/");
                    //return RedirectToAction("Index", "Home");
                }
                else
                {
                    errorMessages = "Login failed.";
                }
            }
            else
            {
                errorMessages = string.Join(" <br /> ", this.ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            }
            ViewBag.Errors = errorMessages;
            return View(input);
        }

        public ActionResult Logout()
        {
            if (1 + 1 == 3)
            {
                FormsIdentity formsIdentity = User.Identity as FormsIdentity;
                FormsAuthenticationTicket ticket = formsIdentity.Ticket;
                string roleData = ticket.UserData;
            }
            string[] allCookies = Request.Cookies.AllKeys;
            foreach (string cookie in allCookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddMinutes(-1);
            }
            HttpContext.Request.Cookies.Clear();
            Session.Clear();
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
        [AllowAnonymous]
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

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View(new ForgotPassword());
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPassword input)
        {
            if (ModelState.IsValid)
            {
                var context = System.Web.HttpContext.Current;
                if (string.IsNullOrEmpty(input.Captcha) || !CaptchaHelper.ValidateCaptchaCode(input.Captcha, context))
                {
                    ViewBag.Errors = "Captcha code do not match";
                    return View(input);
                }

                if (db.tbl_Users.Any(a => a.Email == input.Email))
                {
                    tbl_Users U = db.tbl_Users.FirstOrDefault(a => a.Email == input.Email);

                    var newPassword = System.Web.Security.Membership.GeneratePassword(6, 0);
                    var newMd5Pass = Helper.VerifyMD5.GetMd5Hash(newPassword);
                    U.Password = newMd5Pass;
                    db.SaveChanges();
                    //cần save to other table để quét và gửi email cho người dùng.
                    ViewBag.Info = $"Your password has been re-send to your email, please check your email. {newPassword}";
                }
                else
                {
                    ViewBag.Errors = "Your email is not found !";
                    return View(input);
                }
            }
            return View(input);
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View(new ChangePassword());
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword input)
        {
            if (ModelState.IsValid)
            {
                var UserName = HttpContext.User.Identity.Name;
                tbl_Users user = db.tbl_Users.FirstOrDefault(a => a.UserName == UserName);
                var currentPassMd5 = Helper.VerifyMD5.GetMd5Hash(input.CurrentPassword);
                if (user.Password == currentPassMd5)
                {
                    if (input.NewPassword == input.ConfirmNewPassword)
                    {
                        var newPassMd5 = Helper.VerifyMD5.GetMd5Hash(input.NewPassword);
                        user.Password = newPassMd5;
                        db.SaveChanges();
                        ViewBag.Info = "Your password has been changed successful.";
                        return View(input);

                    }
                    else
                    {
                        ViewBag.Errors = "Confirm password do not match.";
                        return View(input);
                    }
                }
                else
                {
                    ViewBag.Errors = "Current password is incorrect.";
                    return View(input);
                }
            }
            else
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        ViewBag.Error += error + "</br>";
                    }
                }
                return View(input);
            }
            return View(input);
        }

        public ActionResult MyProfile()
        {
            var myProfile = db.tbl_Users.Where(a => a.UserName == User.Identity.Name).Select(a => new MyProfile
            {
                UserName = a.UserName,
                Email = a.Email,
                DisplayName = a.DisplayName,
                Phone = a.Phone,
                MobilePhone = a.MobilePhone,
                ExtNo = string.Empty
            }).FirstOrDefault();
            return View(myProfile);
        }

        [HttpPost]
        public ActionResult MyProfile(MyProfile input)
        {
            var user = db.tbl_Users.FirstOrDefault(a => a.UserName == User.Identity.Name);
            user.Email = input.Email;
            user.DisplayName = input.DisplayName;
            user.Phone = input.Phone;
            user.MobilePhone = input.MobilePhone;
            db.SaveChanges();
            ViewBag.Info = "Your infomation has been updated successful.";
            return View(input);
        }

        public ActionResult PDPA()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PDPA(bool IsAgree)
        {
            if (IsAgree)
            {

            }
            return RedirectToAction("index", "home");
        }
        public PartialViewResult GetMenu()
        {
            var tbl_Users = db.tbl_Users.FirstOrDefault(a => a.UserName == User.Identity.Name);

            return PartialView("MenuPartial", tbl_Users);
        }
    }
}
