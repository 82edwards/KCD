using KcdModel;
using System.Collections.Generic;

namespace KCD.ViewModel
{
    public class EventList
    {
        #region Properties
        public List<Event> PastEvents { get; set; }
        public List<Event> UpcomingEvents { get; set; }
        #endregion

        public EventList()
        {
            PastEvents = Event.GetPastEvents();
            UpcomingEvents = Event.GetUpcomingEvents();
        }
    }
}