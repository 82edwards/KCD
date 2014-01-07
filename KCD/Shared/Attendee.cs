using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace KcdModel
{
    public class Attendee
    {
        #region Properties
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Company { get; set; }
        #endregion

        internal static List<Attendee> GetAttendees(SqlDataReader dr)
        {
            var attendees = new List<Attendee>();
            while (dr.Read())
            {
                attendees.Add(new Attendee
                {
                    Company = Convert.ToString(dr["Company"]),
                    EmailAddress = Convert.ToString(dr["EmailAddress"]),
                    FirstName = Convert.ToString(dr["FirstName"]),
                    LastName = Convert.ToString(dr["LastName"]),
                    AccountId = Convert.ToInt32(dr["AccountId"])
                });
            }
            return attendees;
        }
    }
}
