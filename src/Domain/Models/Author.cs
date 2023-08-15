using Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

        public Author(string name, string email)
        {
            Name = name;
            Email = email;
            ValidateEntity();
        }

        public void ValidateEntity()
        {
            AssertionConcern.AssertArgumentFalse(string.IsNullOrEmpty(Name), "Name must be informed!");
            AssertionConcern.AssertArgumentFalse(string.IsNullOrEmpty(Email), "Email must be informed!");

        }
    }
}