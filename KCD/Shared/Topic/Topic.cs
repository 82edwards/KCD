using Model.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public static IEnumerable<Topic> GetOpenTopics()
        {
            using (var conn = Sql.GetSqlConnection())
            {
                using (var dr = (new SqlCommand { }).ExecuteReader())
                {
                    var results = new List<Topic>();
                    while (dr.Read())
                    {
                        results.Add(new Topic
                        {
                            Id = Convert.ToInt32(dr["TopicId"]),
                            Name = Convert.ToString(dr["TopicName"]),
                            Description = Convert.ToString(dr["TopicDescription"]),
                            SuggestedBy = Convert.ToInt32(dr["SuggestedById"]),
                            SuggestedDate = Convert.ToDateTime(dr["SuggestedDateTime"]),
                            NumberOfVotes = Convert.ToInt32(dr["t.NumberOfVotes"])
                        });
                    }
                    return results;
                }
            }
        }

        public static IEnumerable<Topic> GetAllTopics()
        {
            return null;
        }

        public static IEnumerable<Topic> GetCompletedTopics()
        {
            return null;
        }

        public static Topic GetTopic(int id)
        {
            return null;
        }

        public int CreateTopic()
        {
            return Int32.MinValue;
        }

        public bool UpdateTopic()
        {
            return false;
        }

        public bool UpvoteTopic(int id) { return false; }

        public bool DownvoteTopic(int id) { return false; }
    }
}
