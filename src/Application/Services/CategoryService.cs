using Application.Dtos;
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

        public async Task<ResultService<ReadCategoryDto>> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            if (categoryDto == null)
                return ResultService.Fail<ReadCategoryDto>("The Object is null");

            //var result = new CategoryDtoValidator.Validate(categoryDto);
            //if (!result.IsValid)
            //    return ResultService.RequestError<ReadCategoryDto>("Validation Problem!",result);

            var category = _mapper.Map<Category>(categoryDto);
            var data = await _categoryRepository.AddAsync(category);
            return ResultService.Ok<ReadCategoryDto>(_mapper.Map<ReadCategoryDto>(data));
        }

        public async Task<ResultService> DeleteAsync(int Id)
        {
            var category = await _categoryRepository.GetAsync(Id);
            if (category == null)
                return ResultService.Fail("Category not found!");

            await _categoryRepository.RemoveAsync(category);
            return ResultService.Ok($"Category from Id:{Id} was deleted!");
        }

        public async Task<ResultService<ICollection<ReadCategoryDto>>> GetAsync()
        {
            var category = await _categoryRepository.GetAllAsync();
            return ResultService.Ok<ICollection<ReadCategoryDto>>(_mapper.Map<ICollection<ReadCategoryDto>>(category));
        }

        public async Task<ResultService<ReadCategoryDto>> GetByIdAsync(int Id)
        {
            var category = await _categoryRepository.GetAsync(Id);
            if (category == null)
                return ResultService.Fail<ReadCategoryDto>("Category not found!");

            return ResultService.Ok<ReadCategoryDto>(_mapper.Map<ReadCategoryDto>(category));
        }

        public async Task<ResultService> UpdateAsync(UpdateCategoryDto categoryDto)
        {

            if (categoryDto == null)
                return ResultService.Fail<ReadCategoryDto>("The Object is null!");

            //var validation = new CategoryDtoValidator.Validate(categoryDto);
            //if (!validation.IsValid)
            //    return ResultService.RequestError<ReadCategoryDto>("Validation Problem!",result);

            var category = await _categoryRepository.GetAsync(categoryDto.Id);
            if (category == null)
                return ResultService.Fail("Category not found!");

            category = _mapper.Map<UpdateCategoryDto, Category>(categoryDto, category);
            await _categoryRepository.UpdateAsync(category);
            return ResultService.Ok("Category updated!");
        }
    }
}
