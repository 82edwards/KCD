using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using KcdModel.Helper;

namespace KcdModel.Topic
{
    public class Topic
    {
        public Topic() { }

        public Topic(SqlDataReader dr)
        {
            Id = Convert.ToInt32(dr["TopicId"]);
            Name = Convert.ToString(dr["TopicName"]);
            Description = Convert.ToString(dr["TopicDescription"]);
            SuggestedBy = Convert.ToInt32(dr["SuggestedById"]);
            SuggestedDate = Convert.ToDateTime(dr["SuggestedDateTime"]);
            DateCovered = Convert.ToDateTime(dr["CompletedDateTime"]);
            NumberOfVotes = Convert.ToInt32(dr["NumberOfVotes"]);
        }

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
            return GetTopics("SelectOpenTopics");
        }

        public static IEnumerable<Topic> GetAllTopics()
        {
            return GetTopics("SelectTopics");
        }

        public static IEnumerable<Topic> GetCompletedTopics()
        {
            return GetTopics("SelectCompletedTopics");
        }

        private static IEnumerable<Topic> GetTopics(string storedProcedureName)
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var dr = (new SqlCommand
                {
                    CommandText = storedProcedureName,
                    CommandType = CommandType.StoredProcedure,
                    Connection = conn
                }).ExecuteReader())
                {
                    var results = new List<Topic>();
                    while (dr.Read())
                    {
                        results.Add(new Topic(dr));
                    }

                    return results;
                }
            }
        }

        public static IEnumerable<Topic> GetTopicsByCategory(int categoryId)
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var dr = (new SqlCommand
                {
                    CommandText = "SelectTopicsByCategoryId",
                    CommandType = CommandType.StoredProcedure,
                    Connection = conn,
                    Parameters = { new SqlParameter("@CategoryId", categoryId) }
                }).ExecuteReader())
                {
                    var results = new List<Topic>();
                    while (dr.Read())
                    {
                        results.Add(new Topic(dr));
                    }

                    return results;
                }
            }
        }

        public static Topic GetTopic(int id)
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var dr = (new SqlCommand
                {
                    CommandText = "SelectTopic",
                    CommandType = CommandType.StoredProcedure,
                    Connection = conn,
                    Parameters = { new SqlParameter("@Id", id) }
                }).ExecuteReader())
                {
                    if (!dr.Read())
                        return null;

                    var topic = new Topic(dr);

                    dr.NextResult();
                    topic.Category = new List<Category>();
                    while (dr.Read())
                    {
                        topic.Category.Add(new Category(dr));
                    }

                    dr.NextResult();
                    topic.Comments = new List<Comment>();
                    while (dr.Read())
                    {
                        topic.Comments.Add(new Comment());
                    }


                    return topic;
                }
            }
        }

        public int CreateTopic()
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    CommandText = "InsertTopic",
                    CommandType = CommandType.StoredProcedure,
                    Connection = conn,
                    Parameters = { 
                        new SqlParameter("@TopicName", Name),
                    new SqlParameter("@TopicDescription", Description),
                    new SqlParameter("@SuggestedById", SuggestedBy)                                                                                                                                             }
                })
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool UpdateTopic()
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    CommandText = "UpdateTopic",
                    CommandType = CommandType.StoredProcedure,
                    Connection = conn,
                    Parameters = { 
                        new SqlParameter("@TopicId", Id),
                        new SqlParameter("@TopicName", Name),
                    new SqlParameter("@TopicDescription", Description)                                                                                                                                          }
                })
                {
                    cmd.ExecuteNonQuery();
                    return true;

                }
            }
        }

        public bool UpvoteTopic()
        {
            return VoteOnTopic(Id, NumberOfVotes++);
        }

        public bool DownvoteTopic()
        {
            return VoteOnTopic(Id, NumberOfVotes--);
        }

        private static bool VoteOnTopic(int id, int value)
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    CommandText = "VoteOnTopic",
                    CommandType = CommandType.StoredProcedure,
                    Connection = conn,
                    Parameters = { new SqlParameter("@TopicId", id), new SqlParameter("@NumberOfVotes", value) }
                })
                    cmd.ExecuteNonQuery();
                return true;
            }
        }
    }
}
