using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Services.Interface;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ReadCategoryResponseDto>> CreateCategoryAsync(CreateCategoryRequestDto categoryDto)
        {
            if (categoryDto == null)
                return ResultService.Fail<ReadCategoryResponseDto>("The Object is null");

            //var result = new CategoryDtoValidator.Validate(categoryDto);
            //if (!result.IsValid)
            //    return ResultService.RequestError<ReadCategoryDto>("Validation Problem!",result);

            var category = _mapper.Map<Category>(categoryDto);
            var data = await _categoryRepository.AddAsync(category);
            return ResultService.Ok<ReadCategoryResponseDto>(_mapper.Map<ReadCategoryResponseDto>(data));
        }

        public async Task<ResultService> DeleteAsync(int Id)
        {
            var category = await _categoryRepository.GetAsync(Id);
            if (category == null)
                return ResultService.Fail("Category not found!");

            await _categoryRepository.RemoveAsync(category);
            return ResultService.Ok($"Category from Id:{Id} was deleted!");
        }

        public async Task<ResultService<ICollection<ReadCategoryResponseDto>>> GetAsync()
        {
            var category = await _categoryRepository.GetAllAsync();
            return ResultService.Ok<ICollection<ReadCategoryResponseDto>>(_mapper.Map<ICollection<ReadCategoryResponseDto>>(category));
        }

        public async Task<ResultService<ReadCategoryResponseDto>> GetByIdAsync(int Id)
        {
            var category = await _categoryRepository.GetAsync(Id);
            if (category == null)
                return ResultService.Fail<ReadCategoryResponseDto>("Category not found!");

            return ResultService.Ok<ReadCategoryResponseDto>(_mapper.Map<ReadCategoryResponseDto>(category));
        }

        public async Task<ResultService> UpdateAsync(UpdateCategoryRequestDto categoryDto)
        {

            if (categoryDto == null)
                return ResultService.Fail<ReadCategoryResponseDto>("The Object is null!");

            //var validation = new CategoryDtoValidator.Validate(categoryDto);
            //if (!validation.IsValid)
            //    return ResultService.RequestError<ReadCategoryDto>("Validation Problem!",result);

            var category = await _categoryRepository.GetAsync(categoryDto.Id);
            if (category == null)
                return ResultService.Fail("Category not found!");

            category = _mapper.Map<UpdateCategoryRequestDto, Category>(categoryDto, category);
            await _categoryRepository.UpdateAsync(category);
            return ResultService.Ok("Category updated!");
        }
    }
}
