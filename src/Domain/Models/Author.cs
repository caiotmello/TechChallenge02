using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Author
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}