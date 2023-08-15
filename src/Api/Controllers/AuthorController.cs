using Application.Dtos;
using Application.Services;
using Application.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateAuthorDto auhtorDto)
        {
            var result = await _authorService.CreateAuthorAsync(auhtorDto);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _authorService.GetAsync();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _authorService.GetByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAuthorDto authorDto)
        {
            var result = await _authorService.UpdateAsync(authorDto);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _authorService.DeleteAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
