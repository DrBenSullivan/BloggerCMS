namespace BloggerCMS.Domain.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;

        public AccountDTO() { }
    }
}
