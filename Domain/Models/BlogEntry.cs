using System.ComponentModel.DataAnnotations;

namespace BloggerCMS.Domain.Models
{
    public class BlogEntry
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
        public Blog Blog { get; set; } = null!;
        public DateTime DatePosted { get; set; } = DateTime.Now;

        // Foreign keys
        public int BlogId { get; set; }
    }
}
