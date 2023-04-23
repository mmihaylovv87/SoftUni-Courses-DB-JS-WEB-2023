using ADONET;
using Microsoft.Data.SqlClient;

namespace P01.InitialSetup
{
    public class StartUp
    {
        public static async Task Main()
        {
            SqlConnection sqlConnection = new SqlConnection(Configuration.DATABASE_CONNECTION_STRING);
            await sqlConnection.OpenAsync();

            SqlCommand command = new SqlCommand(Queries.CREATE_DATABASE_MINIONSDB, sqlConnection);
            await command.ExecuteNonQueryAsync();

            await using SqlConnection dataBaseConnection = new SqlConnection(Configuration.DATABASE_CONNECTION_STRING);
            await dataBaseConnection.OpenAsync();

            command = new SqlCommand(Queries.CREATE_TABLES_MINIONSDB, dataBaseConnection);
            await command.ExecuteNonQueryAsync();
           
            command = new SqlCommand(Queries.INSERT_INTO_TABLES_IN_MINIONSDB, dataBaseConnection);
            await command.ExecuteNonQueryAsync();
        }
    }
}