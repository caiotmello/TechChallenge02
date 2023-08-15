using Application.Dtos;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers
{
    public class ModelToDtoMappingAuthor : Profile
    {
        public ModelToDtoMappingAuthor()
        {
            MappingAuthor();
        }

        private void MappingAuthor()
        {
            CreateMap<Author, ReadAuthorDto>();
        }
    }
}
