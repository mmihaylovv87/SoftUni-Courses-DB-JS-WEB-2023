using ADONET;
using Microsoft.Data.SqlClient;

namespace P03.MinionNames
{
    class Program
    {
        public static async Task Main()
        {
            SqlConnection sqlConnection = new SqlConnection(Configuration.DATABASE_CONNECTION_STRING);
            await sqlConnection.OpenAsync();

            int villainId = int.Parse(Console.ReadLine());

            await using (sqlConnection)
            {
                await PrintVillainMinionsInfoByIdAsync(sqlConnection, villainId);
            }
        }

        private static async Task PrintVillainMinionsInfoByIdAsync(SqlConnection sqlConnection, int villainId)
        {
            SqlCommand getVillainNameCmd = new SqlCommand(Queries.VILLAIN_NAME_BY_ID, sqlConnection);

            // Prevents SQL Injection
            getVillainNameCmd.Parameters.AddWithValue("@Id", villainId);

            object villainNameObject = await getVillainNameCmd.ExecuteScalarAsync();

            if (villainNameObject == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exissts int he database.");

                return;
            }

            string villainName = (string)villainNameObject;

            SqlCommand villainMinionsInfoCmd = new SqlCommand(Queries.VILLAIN_MINIONS_INFO_BY_ID, sqlConnection);
            villainMinionsInfoCmd.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader sqlDataReader =
                await villainMinionsInfoCmd.ExecuteReaderAsync();

            await using (sqlDataReader)
            {
                Console.WriteLine($"Villain: {villainName}");

                if (!sqlDataReader.HasRows)
                {
                    Console.WriteLine("(no minions)");
                }
                else
                {
                    while (await sqlDataReader.ReadAsync())
                    {
                        long rowNumber = sqlDataReader.GetInt64(0);
                        string minionName = sqlDataReader.GetString(1);
                        int minionAge = sqlDataReader.GetInt32(2);

                        Console.WriteLine($"{rowNumber}. {minionName} {minionAge}");
                    }
                }
            }
        }
    }
}