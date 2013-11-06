using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KCD.Controllers
{
    public class PollController : Controller
    {
        //
        // GET: /Poll/
        public ActionResult CreateAPoll()
        {
            return View();
        }
	}
}