using KcdModel.Security;

namespace KCD.ViewModel
{
    public class CreateAccount
    {
        #region Properties
        public Account Account { get; set; }
        #endregion

        public CreateAccount()
        {
            Account = new Account();
        }
    }
}