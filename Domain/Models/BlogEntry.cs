namespace BloggerCMS.Domain.Models
{
    public class BlogEntry
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime DatePosted { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        #region Constructors

        public BlogEntry(int id, string author, DateTime datePosted, string title, string body)
        {
            Id = id;
            Author = author;
            DatePosted = datePosted;
            Title = title;
            Body = body;
        }

        #endregion Constructors

    }
}
