using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace ADONET
{
    public class StartUp
    {
        public static async Task Main()
        {
            SqlConnection sqlConnection = new SqlConnection(Configuration.CONNECTION_STRING);
            await sqlConnection.OpenAsync();

            SqlCommand sqlCommand = new SqlCommand(Queries.CREATE_DB_QUERY, sqlConnection);
            await sqlCommand.ExecuteNonQueryAsync();
        }
    }
}