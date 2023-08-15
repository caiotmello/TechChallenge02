using Domain.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }       
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
            ValidateEntity();
        }

        public void ValidateEntity()
        {
            AssertionConcern.AssertArgumentFalse(string.IsNullOrEmpty(Name), "Name must be informed!");
            AssertionConcern.AssertArgumentFalse(string.IsNullOrEmpty(Description), "Description must be informed!");

        }
    }
}