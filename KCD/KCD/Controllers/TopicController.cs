using Model.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KCD.Controllers
{
    public class TopicController : Controller
    {
        public ActionResult SuggestTopic()
        {
            return View(new Topic());
        }
	}
}