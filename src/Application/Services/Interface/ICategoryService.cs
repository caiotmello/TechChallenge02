using Application.Dtos;

namespace Application.Services.Interface
{
    public interface ICategoryService
    {
        Task<ResultService<ReadCategoryDto>> CreateCategoryAsync(CreateCategoryDto categoryDto);
        Task<ResultService<ICollection<ReadCategoryDto>>> GetAsync();
        Task<ResultService<ReadCategoryDto>> GetByIdAsync(int Id);
        Task<ResultService> UpdateAsync(UpdateCategoryDto categoryDto);
        Task<ResultService> DeleteAsync(int Id);
    }
}
