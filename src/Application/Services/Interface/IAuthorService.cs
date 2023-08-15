using Application.Dtos;

namespace Application.Services.Interface
{
    public interface IAuthorService
    {
        Task<ResultService<ReadAuthorDto>> CreateAuthorAsync(CreateAuthorDto authorDto);
        Task<ResultService<ICollection<ReadAuthorDto>>> GetAsync();
        Task<ResultService<ReadAuthorDto>> GetByIdAsync(int Id);
        Task<ResultService> UpdateAsync(UpdateAuthorDto authorDto);
        Task<ResultService> DeleteAsync(int Id);
    }
}
