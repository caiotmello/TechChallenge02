using Application.Mappers;
using Application.Services;
using Application.Services.Interface;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure.CrossCutting.Ioc
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddSqlDb(this IServiceCollection servicesCollection, IConfiguration config)
        {
            servicesCollection.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("SqlConnection")));

            return servicesCollection;
        }

        public static IServiceCollection AddServices(this IServiceCollection servicesCollection)
        {
            //servicesCollection.TryAddSingleton(AppDomain.CurrentDomain.GetAssemblies());
            //servicesCollection.AddAutoMapper(typeof(DtoToModelMappingArticle));
            //servicesCollection.AddAutoMapper(typeof(DtoToModelMappingAuthor));
            servicesCollection.AddAutoMapper(typeof(DtoToDomainMapping));

            servicesCollection.TryAddScoped<IArticleService, ArticleService>();
            servicesCollection.TryAddScoped<IAuthorService, AuthorService>();
            servicesCollection.TryAddScoped<ICategoryService, CategoryService>();

            return servicesCollection;
        }


        /*
        public static IServiceCollection AddApplicationServices(this IServiceCollection servicesCollection)
        {
            servicesCollection.TryAddScoped<ICustomerApplication, CustomerApplication>();
            servicesCollection.TryAddScoped<IDocumentApplication, DocumentApplication>();

            return servicesCollection;
        }*/

        public static IServiceCollection AddRepositories(this IServiceCollection servicesCollection)
        {
            servicesCollection.TryAddScoped<IArticleRepository, ArticleRepository>();
            servicesCollection.TryAddScoped<IAuthorRepository, AuthorRepository>();
            servicesCollection.TryAddScoped<ICategoryRepository, CategoryRepository>();

            return servicesCollection;
        }
    }
}
