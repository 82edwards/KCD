using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Poll
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
