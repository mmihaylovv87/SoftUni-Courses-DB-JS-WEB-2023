using Microsoft.Data.SqlClient;
using ADONET;

namespace P02.VillainNames
{
    public class StartUp
    {
        public static async Task Main()
        {
            SqlConnection sqlConnection = new SqlConnection(Configuration.DATABASE_CONNECTION_STRING);
            await sqlConnection.OpenAsync();

            await using (sqlConnection)
            {
                await PrintVillainsWithMoreThan3MinionsAsync(sqlConnection);
            }
        }

        private static async Task PrintVillainsWithMoreThan3MinionsAsync(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(Queries.VILLAINS_WITH_MORE_THAN_3_MINIONS, sqlConnection);

            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            await using (sqlDataReader)
            {
                while (await sqlDataReader.ReadAsync())
                {
                    string villainName = sqlDataReader.GetString(0);
                    int minionsCount = sqlDataReader.GetInt32(1);

                    Console.WriteLine($"{villainName} - {minionsCount}");
                }
            }
        }
    }
}