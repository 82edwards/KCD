using Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Poll
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
