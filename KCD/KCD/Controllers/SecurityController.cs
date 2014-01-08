using KCD.ViewModel;
using KcdModel.Security;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

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
            account.Password = SecurePassword(account.Password);
            account.Create();

            return RedirectToAction("CreateAnAccount");
        }

        [HttpPost]
        public JsonResult Login(string userName, string password)
        {
            password = SecurePassword(password);

            var result = @"{""Success"":""" + Account.Authenticate(userName, password) + @"""}";

            return Json(result, "application/json");
        }

        private static string SecurePassword(string password)
        {
            var passwordArray = Encoding.ASCII.GetBytes(password);
            return Encoding.ASCII.GetString(MachineKey.Protect(passwordArray, "Authentication token"));
        }
    }
}