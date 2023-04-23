using ADONET;
using Microsoft.Data.SqlClient;
using static Azure.Core.HttpHeader;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace P05.ChangeTownNamesCasing
{ 
    public class StartUp
    {
        public static async Task Main()
        {
            SqlConnection sqlConnection = new SqlConnection(Configuration.DATABASE_CONNECTION_STRING);
            await sqlConnection.OpenAsync();

            string countryName = Console.ReadLine();

            await using (sqlConnection)
            {
                await ChangeTownNamesCasingAsync(sqlConnection, countryName);
            }
        }

        private static async Task ChangeTownNamesCasingAsync(SqlConnection sqlConnection, string countryName)
        {
            SqlCommand updateTownNameByCountry = new SqlCommand(Queries.UPDATE_TOWNS_QUERY, sqlConnection);
            updateTownNameByCountry.Parameters.AddWithValue("@countryName", countryName);

            int rowsAffected = await updateTownNameByCountry.ExecuteNonQueryAsync();

            if (rowsAffected == 0)
            {
                Console.WriteLine("No town names were affected.");

                return;
            }

            SqlCommand getTownName = new SqlCommand(Queries.TOWN_NAME_BY_COUNTRY, sqlConnection);
            getTownName.Parameters.AddWithValue("@countryName", countryName);

            HashSet<string> towns = new HashSet<string>();
            SqlDataReader reader = await getTownName.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                towns.Add(reader["Name"].ToString());
            }

            Console.WriteLine($"{towns.Count} town names were affected.");
            Console.WriteLine($"[{string.Join(", ", towns)}]");
        }
    }
}