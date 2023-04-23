namespace P02_FootballBetting
{
    using Microsoft.EntityFrameworkCore;
    using P02_FootballBetting.Data;

    public class StartUp
    {
        public static void Main()
        {
            FootballBettingContext db = new FootballBettingContext();

            db.Database.Migrate();

            Console.WriteLine("Db created successfully!");
        }
    }
}