using System.ComponentModel.DataAnnotations;

namespace BloggerCMS.Domain.FormModels
{
    public class NewEntryFormModel
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int BlogId { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string Body { get; set; } = null!;
    }
}
