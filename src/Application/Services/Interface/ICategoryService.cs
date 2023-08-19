using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Services.Interface
{
    public interface ICategoryService
    {
        Task<ResultService<ReadCategoryResponseDto>> CreateCategoryAsync(CreateCategoryRequestDto categoryDto);
        Task<ResultService<ICollection<ReadCategoryResponseDto>>> GetAsync();
        Task<ResultService<ReadCategoryResponseDto>> GetByIdAsync(int Id);
        Task<ResultService> UpdateAsync(UpdateCategoryRequestDto categoryDto);
        Task<ResultService> DeleteAsync(int Id);
    }
}
