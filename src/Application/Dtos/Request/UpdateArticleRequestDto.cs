namespace Application.Dtos.Request
{
    public class UpdateArticleRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
