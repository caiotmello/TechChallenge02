using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}