using Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Article(string title, string content,int authorId, int categoryId) 
        {
            Title = title;
            Content = content;
            AuthorId = authorId;
            CategoryId = categoryId;
            PublishedDate = DateTime.Now;
            ModifiedDate = PublishedDate;
            ValidateEntity();
        }

        public void ValidateEntity()
        {
            AssertionConcern.AssertArgumentFalse(string.IsNullOrEmpty(Title), "Name must be informed!");
            AssertionConcern.AssertArgumentFalse(string.IsNullOrEmpty(Content), "Content must be informed!");
            AssertionConcern.AssertArgumentFalse(AuthorId <= 0 , "Author Id must be informed!");
            AssertionConcern.AssertArgumentFalse(CategoryId <= 0, "Category Id must be informed!");
            
        }

    }
}