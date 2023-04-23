using CodeFirst.Models;

namespace CodeFirst
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            db.Categories.Add(new Category
            {
                Title = "Sport",
                News = new List<News> 
                {
                    new News
                    {
                        Title = "Levski",
                        Content = "Levski bie Cska 7:2",
                        Comments = new List<Comment>
                        {
                            new Comment { Author = "Niki", Content = "da"},
                            new Comment { Author = "Stoyan", Content = "ne"},
                        }
                    }
                }
            });
            db.SaveChanges();
        }
    }
}