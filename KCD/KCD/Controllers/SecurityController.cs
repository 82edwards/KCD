using KCD.ViewModel;
using System.Web.Mvc;
using KcdModel.Security;

namespace KCD.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult CreateAnAccount()
        {
            return View(new CreateAccount());
        }

        [HttpPost]
        public ActionResult CreateAnAccount(Account account)
        {
            account.Create();

            return RedirectToAction("CreateAnAccount");
        }

        [HttpPost]
        public JsonResult Login(string userName, string password)
        {
            return new JsonResult();
        }
    }
}