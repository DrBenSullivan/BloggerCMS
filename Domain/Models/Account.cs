namespace BloggerCMS.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public List<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
