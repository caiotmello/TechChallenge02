namespace Application.Dtos.Response
{
    public class ReadArticleResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ReadAuthorResponseDto Author { get; set; }
        public ReadCategoryResponseDto Category { get; set; }
    }
}
