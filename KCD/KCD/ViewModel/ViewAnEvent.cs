using KcdModel;

namespace KCD.ViewModel
{
    public class ViewAnEvent
    {
        #region Properties
        public Event Event { get; set; }
        #endregion

        public ViewAnEvent(int eventId)
        {
            Event = new Event(eventId);
        }
    }
}