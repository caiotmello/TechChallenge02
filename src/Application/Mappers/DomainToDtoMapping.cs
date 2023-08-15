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
            CreateMap<Article, ReadArticleDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(article => article.Author))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(article => article.Category));
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
