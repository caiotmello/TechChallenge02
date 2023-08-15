using Application.Dtos;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            MappingArticle();
            MappingAuthor();
            MappingCategory();
        }

        private void MappingArticle()
        {
            CreateMap<CreateArticleDto, Article>();
            CreateMap<UpdateArticleDto, Article>();
        }

        private void MappingAuthor()
        {
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();
        }

        private void MappingCategory()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
