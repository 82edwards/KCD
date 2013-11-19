using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Topic
{
    public class Comment
    {
        #region Properties
        #endregion

        public int AddComment() { return Int32.MinValue; }

        public static bool DeleteComment(int id) { return false; }

        public static bool UpVoteComment(int id) { return false; }

        public static bool DownVoteComment(int id) { return false; }
    }
}
