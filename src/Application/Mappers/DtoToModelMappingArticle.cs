using Application.Dtos;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers
{
    public class DtoToModelMappingArticle : Profile
    {
        public DtoToModelMappingArticle()
        {
            MappingArticle();
        }

        private void MappingArticle()
        {
            CreateMap<CreateArticleDto, Article>();
            CreateMap<UpdateArticleDto, Article>();
        }
    }
}
