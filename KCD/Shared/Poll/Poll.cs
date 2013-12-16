using System.Collections.Generic;

namespace KcdModel.Poll
{
    public class Poll
    {
        #region Properties
        public int Id { get; set; }
        public string Question { get; set; }
        public Dictionary<int, string> Answers { get; set; }
        public int NumberOfDays { get; set; }
        #endregion
    }
}
