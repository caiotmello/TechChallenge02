using Domain.Core.Interface.Repositories;
using Infrastructure.Data;
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

        /*public static IServiceCollection AddDomainServices(this IServiceCollection servicesCollection)
        {
            servicesCollection.TryAddScoped<ICustomerService, CustomerService>();
            servicesCollection.TryAddScoped<IDocumentService, DocumentService>();

            return servicesCollection;
        }

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
