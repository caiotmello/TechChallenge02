using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Models
{
    public class Article
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}