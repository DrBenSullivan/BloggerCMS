namespace BloggerCMS.Domain.DTO
{
    public class BlogEntryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;   
        public string Body { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int BlogId { get; set; }
    }
}
