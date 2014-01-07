using System.Web.Mvc;
using KcdModel.Discussions;
using KcdModel.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KcdModel
{
    public class Event
    {
        #region Properties

        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public List<Topic> Topics { get; set; }
        public List<Attendee> Attendees { get; set; }

        #endregion

        public Event(SqlDataReader dr)
        {
            GetValue(dr);
        }

        private void GetValue(SqlDataReader dr)
        {
            EventId = Convert.ToInt32(dr["EventId"]);
            EventTitle = Convert.ToString(dr["EventTitle"]);
            EventDescription = Convert.ToString(dr["EventDescription"]);
            EventDate = Convert.ToDateTime(dr["EventDate"]);
        }

        public Event(int eventId)
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var dr = (new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "dbo.SelectEventById",
                    Parameters = { new SqlParameter("@EventId", eventId) }
                }).ExecuteReader())
                {
                    if (dr.Read())
                    {
                        GetValue(dr);
                    }

                    dr.NextResult();
                    Topics = Topic.GetTopics(dr);
                    dr.NextResult();
                    Attendees = Attendee.GetAttendees(dr);
                }
            }
        }

        public static List<Event> GetUpcomingEvents()
        {
            return GetEvent("dbo.SelectUpcomingEvents");
        }

        public static List<Event> GetPastEvents()
        {
            return GetEvent("dbo.SelectPastEvents");
        }

        private static List<Event> GetEvent(string storedProcedureName)
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var dr = (new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = storedProcedureName
                }).ExecuteReader())
                {
                    var result = new List<Event>();
                    while (dr.Read())
                        result.Add(new Event(dr));
                    return result;
                }
            }
        }
    }
}