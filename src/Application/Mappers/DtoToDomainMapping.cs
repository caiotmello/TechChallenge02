using Application.Dtos.Request;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Application.Mappers
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            MappingArticle();
            MappingAuthor();
            MappingCategory();
            MappingUser();
        }

        private void MappingArticle()
        {
            CreateMap<CreateArticleRequestDto, Article>();
            CreateMap<UpdateArticleRequestDto, Article>();
        }

        private void MappingAuthor()
        {
            CreateMap<CreateAuthorRequestDto, Author>();
            CreateMap<UpdateAuthorRequestDto, Author>();
        }

        private void MappingCategory()
        {
            CreateMap<CreateCategoryRequestDto, Category>();
            CreateMap<UpdateCategoryRequestDto, Category>();
        }

        private void MappingUser()
        {
            CreateMap<UserSignUpRequestDto,IdentityUser>();
            CreateMap<UserLoginRequestDto,IdentityUser> ();
        }
    }
}
