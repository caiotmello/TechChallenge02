using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Services.Interface
{
    public interface IAuthorService
    {
        Task<ResultService<ReadAuthorResponseDto>> CreateAuthorAsync(CreateAuthorRequestDto authorDto);
        Task<ResultService<ICollection<ReadAuthorResponseDto>>> GetAsync();
        Task<ResultService<ReadAuthorResponseDto>> GetByIdAsync(int Id);
        Task<ResultService> UpdateAsync(UpdateAuthorRequestDto authorDto);
        Task<ResultService> DeleteAsync(int Id);
    }
}
