using KCD.ViewModel;
using System.Web.Mvc;

namespace KCD.Controllers
{
    public class TopicController : Controller
    {
        public ActionResult SuggestTopic()
        {
            return View(new SuggestTopic());
        }
    }
}