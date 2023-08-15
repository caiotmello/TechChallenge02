namespace Application.Dtos
{
    public class ReadAuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<ReadArticleDto> Articles { get; set; }
    }
}
