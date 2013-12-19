using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using KcdModel.Helper;

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

        public void Create()
        {
            using (var conn = Sql.GetSqlConnection())
            {
                using (var cmd = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "",
                    Connection = conn,
                    Parameters = { new SqlParameter() }
                })
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Poll> GetPolls(int pollsStatus)
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var dr = (new SqlCommand
                {
                    Connection = conn,
                    CommandText = "dbo.GetPollsByStatus",
                    CommandType = CommandType.StoredProcedure,
                    Parameters = { new SqlParameter("@StatusId", pollsStatus) }
                }).ExecuteReader())
                {
                    var results = new List<Poll>();
                    while (dr.Read())
                    {
                        results.Add(new Poll());
                    }
                    return results;
                }
            }
        }
    }
}
