using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class CreateArticleDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
