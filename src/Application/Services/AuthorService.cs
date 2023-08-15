using Application.Dtos;
using Application.Services.Interface;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ReadAuthorDto>> CreateAuthorAsync(CreateAuthorDto authorDto)
        {

            if (authorDto == null)
                return ResultService.Fail<ReadAuthorDto>("The Object is null");

            // Validar o DTO usando as Data Annotations
            //var result = new AuthorDtoValidator.Validate(authorDto);
            //if (!result.IsValid)
            //    return ResultService.RequestError<ReadArticleDto>("Validation Problem!",result);

            var author = _mapper.Map<Author>(authorDto);
            var data = await _authorRepository.AddAsync(author);
            return ResultService.Ok<ReadAuthorDto>(_mapper.Map<ReadAuthorDto>(data));
        }

        public async Task<ResultService> DeleteAsync(int Id)
        {
            var author = await _authorRepository.GetAsync(Id);
            if (author == null)
                return ResultService.Fail("Author not found!");

            await _authorRepository.RemoveAsync(author);
            return ResultService.Ok($"Author from Id:{Id} was deleted!");
        }

        public async Task<ResultService<ICollection<ReadAuthorDto>>> GetAsync()
        {
            var author = await _authorRepository.GetAllAsync();
            return ResultService.Ok<ICollection<ReadAuthorDto>>(_mapper.Map<ICollection<ReadAuthorDto>>(author));
        }

        public async Task<ResultService<ReadAuthorDto>> GetByIdAsync(int Id)
        {
            var author = await _authorRepository.GetAsync(Id);
            if (author == null)
                return ResultService.Fail<ReadAuthorDto>("Author not found!");

            return ResultService.Ok<ReadAuthorDto>(_mapper.Map<ReadAuthorDto>(author));
        }

        public async Task<ResultService> UpdateAsync(UpdateAuthorDto authorDto)
        {
            if (authorDto == null)
                return ResultService.Fail<ReadAuthorDto>("The Object is null!");

            //var validation = new AtuhorDtoValidator.Validate(authorDto);
            //if (!validation.IsValid)
            //    return ResultService.RequestError<ReadAuthorDto>("Validation Problem!",result);

            var author = await _authorRepository.GetAsync(authorDto.Id);
            if (author == null)
                return ResultService.Fail("Author not found!");

            author = _mapper.Map<UpdateAuthorDto, Author>(authorDto, author);
            await _authorRepository.UpdateAsync(author);
            return ResultService.Ok("Author updated!");
        }
    }
}
