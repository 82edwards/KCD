using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KcdModel.Poll;

namespace KCD.ViewModel
{
    public class ViewPolls
    {
        #region Properties
        public List<Poll> Polls { get; set; } 
        #endregion

        public ViewPolls(int pollsStatus)
        {
            Polls = Poll.GetPolls(pollsStatus);
        }
    }
}