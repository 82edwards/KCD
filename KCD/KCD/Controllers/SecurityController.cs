using KcdModel.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KCD.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult CreateAnAccount()
        {
            return View(new Account());
        }
	}
}