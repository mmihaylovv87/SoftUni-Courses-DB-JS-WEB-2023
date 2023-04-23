using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Category
    {
        public Category()
        {
            this.News = new HashSet<News>();
        }

        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public ICollection<News> News { get; set; }
    }
}
