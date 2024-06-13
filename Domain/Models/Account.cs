namespace BloggerCMS.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public List<Blog> Blogs { get; set; } = [];

        public Account() { }

        public Account(string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
