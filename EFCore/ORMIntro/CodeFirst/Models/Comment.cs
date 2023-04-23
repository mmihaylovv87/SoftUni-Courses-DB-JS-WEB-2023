using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int NewId { get; set; }

        public News News { get; set; }

        [MaxLength(50)]
        public string Author { get; set; }

        public string Content { get; set; }
    }
}
