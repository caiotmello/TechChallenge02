using Application.Dtos;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers
{
    public class ModelToDtoMappingCategory : Profile
    {
        public ModelToDtoMappingCategory()
        {
            MappingCategory();
        }

        private void MappingCategory()
        {
            CreateMap<Category, ReadCategoryDto>();
        }
    }
}
