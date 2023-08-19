using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Dtos.Validations;
using Application.Services.Interface;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ReadArticleResponseDto>> CreateAsync(CreateArticleRequestDto articleDto)
        {
            if (articleDto == null)
                return ResultService.Fail<ReadArticleResponseDto>("The Object is null!");

            var validation = new CreateArticleRequestDtoValidator().Validate(articleDto);
            if (!validation.IsValid)
                return ResultService.RequestError<ReadArticleResponseDto>("Validation Problem!", validation);

            var article = _mapper.Map<Article>(articleDto);
            var data = await _articleRepository.AddAsync(article);
            return ResultService.Ok<ReadArticleResponseDto>(_mapper.Map<ReadArticleResponseDto>(data));
        }

        public async Task<ResultService> DeleteAsync(int Id)
        {
            var article = await _articleRepository.GetAsync(Id);
            if (article == null)
                return ResultService.Fail("Article not found!");

            await _articleRepository.RemoveAsync(article);
            return ResultService.Ok($"Article from Id:{Id} was deleted!");
        }

        public async Task<ResultService<ICollection<ReadArticleResponseDto>>> GetAsync()
        {
            var articles = await _articleRepository.GetAllAsync();
            return ResultService.Ok<ICollection<ReadArticleResponseDto>>(_mapper.Map<ICollection<ReadArticleResponseDto>>(articles));
        }

        public async Task<ResultService<ReadArticleResponseDto>> GetByIdAsync(int Id)
        {
            var article = await _articleRepository.GetAsync(Id);
            if (article == null)
                return ResultService.Fail<ReadArticleResponseDto>("Article not found!");

            return ResultService.Ok<ReadArticleResponseDto>(_mapper.Map<ReadArticleResponseDto>(article));
        }

        public async Task<ResultService> UpdateAsync(UpdateArticleRequestDto articleDto)
        {
            if (articleDto == null)
                return ResultService.Fail<ReadArticleResponseDto>("The Object is null!");

            var validation = new UpdateArticleRequestDtoValidator().Validate(articleDto);
            if (!validation.IsValid)
                return ResultService.RequestError<ReadArticleResponseDto>("Validation Problem!", validation);

            var article =  await _articleRepository.GetAsync(articleDto.Id);
            if (article == null)
                return ResultService.Fail("Article not found!");

            article = _mapper.Map<UpdateArticleRequestDto,Article>(articleDto, article);
            article.ModifiedDate = DateTime.Now;
            await _articleRepository.UpdateAsync(article);
            return ResultService.Ok("Article updated!");

        }
    }
}
