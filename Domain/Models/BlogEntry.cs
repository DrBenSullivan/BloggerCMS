using System.ComponentModel.DataAnnotations;

namespace BloggerCMS.Domain.Models
{
    public class BlogEntry
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime DatePosted { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
