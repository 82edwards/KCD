using KCD.ViewModel;
using System.Web.Mvc;

namespace KCD.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult CreateAnAccount()
        {
            return View(new CreateAccount());
        }
	}
}