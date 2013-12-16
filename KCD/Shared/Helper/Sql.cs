using System.Configuration;
using System.Data.SqlClient;

namespace KcdModel.Helper
{
    internal class Sql
    {
        internal static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["RealTime"].ConnectionString);
        }
    }
}
