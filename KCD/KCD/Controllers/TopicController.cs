﻿using KCD.ViewModel;
using System.Web.Mvc;

namespace KCD.Controllers
{
    public class TopicController : Controller
    {
        public ActionResult SuggestTopic()
        {
            return View(new SuggestTopic());
        }

        public ActionResult ViewTopics()
        {
            return View(new ViewTopics());
        }

        public ActionResult ViewATopic(int topicId)
        {
            return View(new ViewATopic(topicId));
        }
    }
}