using Application.Dtos.Response;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Application.Mappers
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            MappingArticle();
            MappingAuthor();
            MappingCategory();
            MappingUser();
        }

        private void MappingArticle()
        {
            CreateMap<Article, ReadArticleResponseDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(article => article.Author))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(article => article.Category));
        }

        private void MappingAuthor()
        {
            CreateMap<Author, ReadAuthorResponseDto>();
        }

        private void MappingCategory()
        {
            CreateMap<Category, ReadCategoryResponseDto>();
        }

        private void MappingUser()
        {
            CreateMap<IdentityUser, UserLoginResponseDto>();
        }
    }
}
