using System.ComponentModel;
using System.Net;

namespace Domain.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Author Author { get; set; }

        public Category Category { get; set; }

    }
}