using KcdModel.Discussions;
using System.Collections.Generic;

namespace KcdModel
{
    public class Event
    {
        #region Properties
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public List<Topic> Topics { get; set; }
        public List<Attendee> Attendees { get; set; } 

        #endregion
    }
}
