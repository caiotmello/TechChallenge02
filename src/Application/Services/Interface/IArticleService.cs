using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Services.Interface
{
    public interface IArticleService
    {
        Task<ResultService<ReadArticleResponseDto>> CreateAsync(CreateArticleRequestDto ArticleDto);
        Task<ResultService<ICollection<ReadArticleResponseDto>>> GetAsync();
        Task<ResultService<ReadArticleResponseDto>> GetByIdAsync(int Id);
        Task<ResultService> UpdateAsync(UpdateArticleRequestDto articleDto);
        Task<ResultService> DeleteAsync(int Id);
    }
}
