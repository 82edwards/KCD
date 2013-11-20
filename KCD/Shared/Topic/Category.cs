using Model.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Model.Topic
{
    public class Category
    {
        public Category(SqlDataReader dr)
        {
            Id = Convert.ToInt32(dr["CategoryId"]);
            Name = Convert.ToString(dr["Category"]);
        }

        #region
        public int Id { get; set; }
        public string Name { get; set; }
        #endregion

        public static IEnumerable<Category> GetAllCategories()
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SelectCategories"
                })
                using (var dr = cmd.ExecuteReader())
                {
                    var results = new List<Category>();
                    while (dr.Read())
                    {
                        results.Add(new Category(dr));
                    }
                    return results;
                }
            }
        }

        public static IEnumerable<Category> GetCategoriesByTopic(int topicId)
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SelectCategoriesByTopicId",
                    Parameters = { new SqlParameter("@TopicId", topicId) }
                })
                using (var dr = cmd.ExecuteReader())
                {
                    var results = new List<Category>();
                    while (dr.Read())
                    {
                        results.Add(new Category(dr));
                    }
                    return results;
                }
            }
        }
    }
}
