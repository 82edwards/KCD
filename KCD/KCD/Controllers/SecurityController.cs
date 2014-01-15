﻿using KCD.ViewModel;
using KcdModel.Security;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace KCD.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult CreateAnAccount()
        {
            return View(new CreateAccount());
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAnAccount(Account account)
        {
            if (account != null && !String.IsNullOrEmpty(account.Password))
            {
                account.Password = SecurePassword(account.Password);
                account.Create();
            }

            return RedirectToAction("CreateAnAccount");
        }

        [HttpPost]
        public JsonResult Login(string userName, string password)
        {
            password = SecurePassword(password);
            var result = Account.Authenticate(userName, password);

            if (result)
                CreateCookie(userName);

            return Json(@"{""Success"":""" + result + @"""}", "application/json");
        }

        [HttpPost]
        public JsonResult ResetPassword(string userName, string existingPassword, string newPassword)
        {
            existingPassword = SecurePassword(existingPassword);
            newPassword = SecurePassword(newPassword);
            var result = Account.ResetPassword(userName, existingPassword, newPassword);
            return Json(@"{""Success"":""" + result + @"""}", "application/json");
        }

        private static string SecurePassword(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            data = (new MD5CryptoServiceProvider()).ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }

        private void CreateCookie(string userName)
        {
            Response.Cookies.Add(new HttpCookie("KCD")
            {
                Value = userName,
                Expires = (DateTime.Now).AddMinutes(30)
            });
        }
    }
}