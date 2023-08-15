using Application.Dtos;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            MappingArticle();
            MappingAuthor();
            MappingCategory();
        }

        private void MappingArticle()
        {
            CreateMap<Article, ReadArticleDto>();
        }

        private void MappingAuthor()
        {
            CreateMap<Author, ReadAuthorDto>();
        }

        private void MappingCategory()
        {
            CreateMap<Category, ReadCategoryDto>();
        }
    }
}
