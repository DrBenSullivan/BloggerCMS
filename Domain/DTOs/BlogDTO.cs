namespace BloggerCMS.Domain.DTO
{
    public class BlogDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string AuthorId { get; set; }

        public BlogDTO(int id, string title, string authorId)
        {
            Id = id;
            Title = title;
            AuthorId = authorId;
        }
    }
}
