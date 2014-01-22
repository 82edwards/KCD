using KcdModel.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KcdModel
{
    public class Swag
    {
        public Swag(IDataRecord dr)
        {
            DateRecieved = Convert.ToDateTime(dr["DateRecieved"]);
            LongDescription = Convert.ToString(dr["LongDescription"]);
            QuantityRecieved = Convert.ToInt32(dr["QuantityRecieved"]);
            ShortDescription = Convert.ToString(dr["ShortDescription"]);
            SwagId = Convert.ToInt32(dr["SwagId"]);
        }

        #region Properties
        public int SwagId { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int QuantityRecieved { get; set; }
        public DateTime DateRecieved { get; set; }
        #endregion

        public static IEnumerable<Swag> GetSwags()
        {
            using (var conn = Sql.GetSqlConnection())
            using (var cmd = new SqlCommand
            {
                CommandText = "dbo.SelectSwagItems",
                CommandType = CommandType.StoredProcedure,
                Connection = conn
            })
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    var result = new List<Swag>();
                    while (dr.Read())
                    {
                        result.Add(new Swag(dr));
                    }
                    return result;
                }
            }
        }
    }
}
