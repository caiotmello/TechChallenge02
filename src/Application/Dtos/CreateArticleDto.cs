using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class CreateArticleDto
    {
        [Required(ErrorMessage = "Field Title is mandatory")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Field Content is mandatory")]
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
