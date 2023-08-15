namespace Application.Dtos
{
    public class ReadArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ReadAuthorDto Author { get; set; }
        public ReadCategoryDto Category { get; set; }
    }
}
