using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using KcdModel.Helper;

namespace KcdModel.Security
{
    public class Gender
    {
        #region Properties
        public int Id { get; set; }
        public string Display { get; set; }
        #endregion

        private Gender(int id, string display) 
        {
            Id = id;
            Display = display;
        }

        internal static IEnumerable<Gender> Get()
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("KCD.Security.SelectGenders", conn))
                using (var dr = cmd.ExecuteReader())
                {
                    var genders = new List<Gender>();

                    while (dr.Read())
                        genders.Add(new Gender(Convert.ToInt32(dr["GenderId"]), Convert.ToString(dr["Gender"])));

                    return genders;
                }
            }
        }
    }
}
