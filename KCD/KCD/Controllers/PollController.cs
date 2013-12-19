using System.Web.Mvc;
using KCD.ViewModel;
using KcdModel.Poll;

namespace KCD.Controllers
{
    public class PollController : Controller
    {
        public ActionResult CreateAPoll()
        {
            return View(new CreatePoll());
        }

        [HttpPost]
        public ActionResult CreateAPoll(Poll poll)
        {
            poll.Create();

            return RedirectToAction("CreateAPoll");
        }
    }
}