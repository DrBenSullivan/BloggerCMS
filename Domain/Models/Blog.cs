namespace BloggerCMS.Domain.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<BlogEntry> BlogEntries { get; set; } = new List<BlogEntry>();
        public Account Author { get; set; } = null!;

        // Foreign keys
        public int AuthorId { get; set; }
    }
}
