using Application.Dtos;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers
{
    public class DtoToModelMappingCategory : Profile
    {
        public DtoToModelMappingCategory()
        {
            MappingCategory();
        }

        private void MappingCategory()
        {
            CreateMap<CreateCategoryDto, Category>();
        }
    }
}
