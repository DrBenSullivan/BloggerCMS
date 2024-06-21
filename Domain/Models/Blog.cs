using BloggerCMS.Domain.ViewModels;
namespace BloggerCMS.Domain.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<BlogEntry> BlogEntries { get; set; } = new List<BlogEntry>();

        // Navigation Property
        public Account Author { get; set; } = null!;

        // Foreign key
        public int AuthorId { get; set; }

        #region Constructors
        public Blog() { }

		#endregion
	}

}
