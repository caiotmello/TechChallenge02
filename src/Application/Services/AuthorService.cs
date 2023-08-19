using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Dtos.Validations;
using Application.Services.Interface;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;

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

        public async Task<ResultService<ReadAuthorResponseDto>> CreateAuthorAsync(CreateAuthorRequestDto authorDto)
        {

            if (authorDto == null)
                return ResultService.Fail<ReadAuthorResponseDto>("The Object is null");

            // Validar o DTO usando as Data Annotations
            var validation = new CreateAuthorRequestDtoValidator().Validate(authorDto);
            if (!validation.IsValid)
                return ResultService.RequestError<ReadAuthorResponseDto>("Validation Problem!", validation);

            var author = _mapper.Map<Author>(authorDto);
            var data = await _authorRepository.AddAsync(author);
            return ResultService.Ok<ReadAuthorResponseDto>(_mapper.Map<ReadAuthorResponseDto>(data));
        }

        public async Task<ResultService> DeleteAsync(int Id)
        {
            var author = await _authorRepository.GetAsync(Id);
            if (author == null)
                return ResultService.Fail("Author not found!");

            await _authorRepository.RemoveAsync(author);
            return ResultService.Ok($"Author from Id:{Id} was deleted!");
        }

        public async Task<ResultService<ICollection<ReadAuthorResponseDto>>> GetAsync()
        {
            var author = await _authorRepository.GetAllAsync();
            return ResultService.Ok<ICollection<ReadAuthorResponseDto>>(_mapper.Map<ICollection<ReadAuthorResponseDto>>(author));
        }

        public async Task<ResultService<ReadAuthorResponseDto>> GetByIdAsync(int Id)
        {
            var author = await _authorRepository.GetAsync(Id);
            if (author == null)
                return ResultService.Fail<ReadAuthorResponseDto>("Author not found!");

            return ResultService.Ok<ReadAuthorResponseDto>(_mapper.Map<ReadAuthorResponseDto>(author));
        }

        public async Task<ResultService> UpdateAsync(UpdateAuthorRequestDto authorDto)
        {
            if (authorDto == null)
                return ResultService.Fail<ReadAuthorResponseDto>("The Object is null!");

            var validation = new UpdateAuthorRequestDtoValidator().Validate(authorDto);
            if (!validation.IsValid)
                return ResultService.RequestError("Validation Problem!", validation);

            var author = await _authorRepository.GetAsync(authorDto.Id);
            if (author == null)
                return ResultService.Fail("Author not found!");

            author = _mapper.Map<UpdateAuthorRequestDto, Author>(authorDto, author);
            await _authorRepository.UpdateAsync(author);
            return ResultService.Ok("Author updated!");
        }
    }
}
