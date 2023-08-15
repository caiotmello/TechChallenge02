using Application.Dtos;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers
{
    public class DtoToModelMappingAuthor : Profile
    {
        public DtoToModelMappingAuthor()
        {
            MappingAuthor();
        }

        private void MappingAuthor()
        {
            CreateMap<CreateAuthorDto, Author>();
        }
    }
}
