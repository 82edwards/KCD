using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Security
{
    public class Account
    {
        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Company { get; set; }
        public bool CanSendEmails { get; set; }
        public bool CanBeContactedBySponsers { get; set; }
        public string Password { get; set; }
        #endregion
    }
}
