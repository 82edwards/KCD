using KCD.ViewModel;
using KcdModel.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace KCD.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult CreateAnAccount()
        {
            return View(new CreateAccount());
        }

        public ActionResult ResetPassword()
        {
            return View();
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

            return Json(@"{""Success"":""" + Account.Authenticate(userName, password) + @"""}", "application/json");
        }

        [HttpPost]
        public JsonResult ResetPassword(string userName, string existingPassword, string newPassword)
        {
            existingPassword = SecurePassword(existingPassword);
            newPassword = SecurePassword(newPassword);
            var result = Account.ResetPassword(userName, existingPassword, newPassword);
            return Json(@"{""Success"":""" + result + @"""}", "application/json");
        }

        private static string SecurePassword(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            data = (new MD5CryptoServiceProvider()).ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }
    }
}