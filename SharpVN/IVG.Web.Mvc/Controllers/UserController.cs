﻿using IVG.Web.Mvc.EF;
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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login input)
        {
            var passMd5 = Helper.VerifyMD5.GetMd5Hash(input.Password);
            tbl_Users user = db.tbl_Users.FirstOrDefault(a => a.UserName == input.UserName && a.Password == passMd5);
            if (user != null)
            {
                var UserJsonString = JsonConvert.SerializeObject(user, Formatting.Indented);
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now,
                DateTime.Now.AddSeconds(30), input.Remember, UserJsonString);
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (input.Remember)
                    ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);
                return RedirectToAction("Index", "Home");
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
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
