using Application.Dtos;
using Application.Services;
using Application.Services.Interface;
using Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateCategoryDto categoryDto)
        {
            try
            {
                var result = await _categoryService.CreateCategoryAsync(categoryDto);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _categoryService.GetAsync();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryDto categoryDto)
        {
            var result = await _categoryService.UpdateAsync(categoryDto);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
