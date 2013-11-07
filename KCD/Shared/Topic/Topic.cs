using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Topic
{
    public class Topic
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SuggestedBy { get; set; }
        public DateTime SuggestedDate { get; set; }
        public DateTime DateCovered { get; set; }
        public int NumberOfVotes { get; set; }
        public List<Category> Category { get; set; }
        public List<Comment> Comments { get; set; }
        #endregion
    }
}
