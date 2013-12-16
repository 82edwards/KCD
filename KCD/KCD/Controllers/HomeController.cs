﻿using System.Web.Mvc;
using KCD.ViewModel;

namespace KCD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateAnAccount()
        {
            return View(new CreateAccount());
        }
    }
}