using Microsoft.Data.SqlClient;
using ADONET;

namespace P04.AddMinion
{
    public class StartUp
    {
        public static async Task Main()
        {
            SqlConnection sqlConnection = new SqlConnection(Configuration.DATABASE_CONNECTION_STRING);
            await sqlConnection.OpenAsync();

            Console.WriteLine("Enter minion info: ");
            string[] minionInfo = Console.ReadLine()?
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string townName = minionInfo[3];

            Console.WriteLine("Enter villain info: ");
            string villainName = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];

            await using (sqlConnection)
            {
                await AddMinionAsync(sqlConnection, minionName, minionAge, townName, villainName);
            }
        }

        private static async Task AddMinionAsync(SqlConnection sqlConnection, string minionName,
            int minionAge, string townName, string villainName)
        {
            SqlCommand getTownIdCmd = new SqlCommand(Queries.ID_BY_TOWN_NAME, sqlConnection);
            getTownIdCmd.Parameters.AddWithValue("@townName", townName);

            object townIdObject = await getTownIdCmd.ExecuteScalarAsync();

            if (townIdObject == null)
            {
                SqlCommand insertTownCmd = new SqlCommand(Queries.INSERT_TOWN, sqlConnection);
                insertTownCmd.Parameters.AddWithValue("@townName", townName);

                int rowsAffectedT = await insertTownCmd.ExecuteNonQueryAsync();

                if (rowsAffectedT == 0)
                {
                    Console.WriteLine("Problem occured while inserting new town into the database MinionsDB!" +
                        " Please try again later!");

                    return;
                }

                townIdObject = await getTownIdCmd.ExecuteScalarAsync();
                Console.WriteLine($"Town {townName} was added to the database.");
            }

            int townId = (int)townIdObject;

            SqlCommand getVillainIdCmd = new SqlCommand(Queries.ID_BY_VILLAIN_NAME, sqlConnection);
            getVillainIdCmd.Parameters.AddWithValue("@Name", villainName);

            object villainIdOnject = await getVillainIdCmd.ExecuteScalarAsync();

            if (villainIdOnject == null)
            {
                SqlCommand insertVillainCmd = new SqlCommand(Queries.INSERT_VILLAIN, sqlConnection);
                insertVillainCmd.Parameters.AddWithValue("@villainName", villainName);

                int rowsAffectedV = await insertVillainCmd.ExecuteNonQueryAsync();

                if (rowsAffectedV == 0)
                {
                    Console.WriteLine("Problem occured while inserting new villain into the database MinionsDB!" +
                        " Please try again later!");
                    return;
                }

                villainIdOnject = await getVillainIdCmd.ExecuteScalarAsync();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            int villainId = (int)villainIdOnject;

            SqlCommand insertMinionCmd = new SqlCommand(Queries.INSERT_MINION, sqlConnection);

            insertMinionCmd.Parameters.AddWithValue("@name", minionName);
            insertMinionCmd.Parameters.AddWithValue("@age", minionAge);
            insertMinionCmd.Parameters.AddWithValue("@townId", townId);

            int rowsAffected = await insertMinionCmd.ExecuteNonQueryAsync();

            if (rowsAffected == 0)
            {
                Console.WriteLine("Problem occured while inserting new minion into the database MinionsDB!" +
                    " Please try again later!");
                return;
            }

            SqlCommand getMinionIdCmd = new SqlCommand(Queries.ID_BY_MINION_NAME, sqlConnection);
            getMinionIdCmd.Parameters.AddWithValue("@Name", minionName);

            int minionId = (int)await getMinionIdCmd.ExecuteScalarAsync();

            SqlCommand insertMinionVillainCmd = new SqlCommand(Queries.INSERT_MINION_VILLAIN, sqlConnection);
            insertMinionVillainCmd.Parameters.AddWithValue("@villainId", villainId);
            insertMinionVillainCmd.Parameters.AddWithValue("@minionId", minionId);

            int rowsAffectedMV = await insertMinionVillainCmd.ExecuteNonQueryAsync();

            if (rowsAffectedMV == 0)
            {
                Console.WriteLine("Problem occured while inserting new minion under the control of the given villain!" +
                    " Please try again later!");

                return;
            }

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }
    }
}