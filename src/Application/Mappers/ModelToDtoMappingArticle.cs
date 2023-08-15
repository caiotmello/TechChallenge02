using Application.Dtos;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers
{
    public class ModelToDtoMappingArticle : Profile
    {
        public ModelToDtoMappingArticle()
        {
            MappingArticle();
        }

        private void MappingArticle()
        {
            CreateMap<Article, ReadArticleDto>();
        }
    }
}
