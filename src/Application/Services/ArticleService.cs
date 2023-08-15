using Application.Dtos;
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

        public async Task<ResultService<ReadArticleDto>> CreateAsync(CreateArticleDto articleDto)
        {
            if (articleDto == null)
                return ResultService.Fail<ReadArticleDto>("The Object is null!");

            var validation = new CreateArticleDtoValidator().Validate(articleDto);
            if (!validation.IsValid)
                return ResultService.RequestError<ReadArticleDto>("Validation Problem!", validation);

            var article = _mapper.Map<Article>(articleDto);
            var data = await _articleRepository.AddAsync(article);
            return ResultService.Ok<ReadArticleDto>(_mapper.Map<ReadArticleDto>(data));
        }

        public async Task<ResultService> DeleteAsync(int Id)
        {
            var article = await _articleRepository.GetAsync(Id);
            if (article == null)
                return ResultService.Fail("Article not found!");

            await _articleRepository.RemoveAsync(article);
            return ResultService.Ok($"Article from Id:{Id} was deleted!");
        }

        public async Task<ResultService<ICollection<ReadArticleDto>>> GetAsync()
        {
            var articles = await _articleRepository.GetAllAsync();
            return ResultService.Ok<ICollection<ReadArticleDto>>(_mapper.Map<ICollection<ReadArticleDto>>(articles));
        }

        public async Task<ResultService<ReadArticleDto>> GetByIdAsync(int Id)
        {
            var article = await _articleRepository.GetAsync(Id);
            if (article == null)
                return ResultService.Fail<ReadArticleDto>("Article not found!");

            return ResultService.Ok<ReadArticleDto>(_mapper.Map<ReadArticleDto>(article));
        }

        public async Task<ResultService> UpdateAsync(UpdateArticleDto articleDto)
        {
            if (articleDto == null)
                return ResultService.Fail<ReadArticleDto>("The Object is null!");

            var validation = new UpdateArticleDtoValidator().Validate(articleDto);
            if (!validation.IsValid)
                return ResultService.RequestError<ReadArticleDto>("Validation Problem!", validation);

            var article =  await _articleRepository.GetAsync(articleDto.Id);
            if (article == null)
                return ResultService.Fail("Article not found!");

            article = _mapper.Map<UpdateArticleDto,Article>(articleDto, article);
            article.ModifiedDate = DateTime.Now;
            await _articleRepository.UpdateAsync(article);
            return ResultService.Ok("Article updated!");

        }
    }
}
