using KcdModel.Security;

namespace KcdModel.Poll
{
    public class Vote
    {
        #region Properties
        public Poll Pool { get; set; }
        public int AnswerId { get; set; }
        public User AnsweredBy { get; set; }
        #endregion
    }
}
