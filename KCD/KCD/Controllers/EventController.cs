using System.Web.Mvc;
using KCD.ViewModel;

namespace KCD.Controllers
{
    public class EventController : Controller
    {
        public ActionResult EventList()
        {
            return View(new EventList());
        }
    }
}