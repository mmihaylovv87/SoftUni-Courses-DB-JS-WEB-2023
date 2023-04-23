namespace BookShop
{
    using Data;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(dbContext); 

            int result = RemoveBooks(dbContext);

            Console.WriteLine(result);
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            var bookCategories = context.BooksCategories
                .Where(bc => bc.Book.Copies < 4200)
                .ToArray();

            context.BooksCategories.RemoveRange(bookCategories);
            context.Books.RemoveRange(books);

            context.SaveChanges();

            return books.Length;
        }
    }
}