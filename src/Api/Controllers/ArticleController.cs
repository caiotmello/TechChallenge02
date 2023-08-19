using Application.Dtos.Request;
using Application.Services;
using Application.Services.Interface;
using Domain.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateArticleRequestDto articleDto)
        {
            try
            {
                var result = await _articleService.CreateAsync(articleDto);
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
        public  async Task<IActionResult> GetAsync()
        {
            var result = await _articleService.GetAsync();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _articleService.GetByIdAsync(id);
            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateArticleRequestDto articleDto)
        {
            var result = await _articleService.UpdateAsync(articleDto);
            if(result.IsSuccess) 
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _articleService.DeleteAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
