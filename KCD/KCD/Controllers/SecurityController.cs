using KCD.ViewModel;
using KcdModel.Security;
using System.Web.Mvc;

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
            var result = @"{""Success"":""" + Account.Authenticate(userName, password) + @"""}";

            return Json(result, "application/json");
        }
    }
}