using System.Web.Mvc;
using KCD.ViewModel;

namespace KCD.Controllers
{
    public class PollController : Controller
    {
        public ActionResult CreateAPoll()
        {
            return View(new CreatePoll());
        }
    }
}