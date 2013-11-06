using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Model.Security
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
        public SelectList Gender
        {
            get
            {
                var genders = from GenderEnum s in Enum.GetValues(typeof(GenderEnum))
                              select new { Value = s, Text = s.ToString() };
                return new SelectList(genders, "Value", "Text");
            }
        }
        #endregion

        private enum GenderEnum
        {
            Male = 1,
            Female = 2,
            Abstain = 3
        }
    }

}
