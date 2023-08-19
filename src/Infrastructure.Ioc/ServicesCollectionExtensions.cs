using Application.Mappers;
using Application.Services;
using Application.Services.Interface;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Infrastructure.Identity.Configurations;
using Infrastructure.Identity.Data;
using Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.CrossCutting.Ioc
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddSqlDb(this IServiceCollection servicesCollection, IConfiguration config)
        {
            servicesCollection.AddDbContext<AppDbContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(config.GetConnectionString("SqlConnection")));
            //options.UseSqlServer(config.GetConnectionString("SqlConnection")));

            servicesCollection.AddDbContext<IdentityDataContext>(options =>
            options.UseSqlServer(config.GetConnectionString("SqlConnection")));

            return servicesCollection;
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection servicesCollection, IConfiguration config)
        {
            //Read AppSetting to create a IConfiguration object called jwtoptions to be inject futher.
            var jwtAppSettingOptions = config.GetSection(nameof(JwtOptions));
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.GetSection("JwtOptions:SecurityKey").Value));

            servicesCollection.Configure<JwtOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                options.Expiration = int.Parse(jwtAppSettingOptions[nameof(JwtOptions.Expiration)] ?? "0");
            });

            //Identity configuratons
            servicesCollection.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();

            servicesCollection.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            servicesCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = config.GetSection("JwtOptions:Issuer").Value,
                    ValidateAudience = true,
                    ValidAudience = config.GetSection("JwtOptions:Audience").Value,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    RequireExpirationTime= true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            return servicesCollection;
        }
        public static IServiceCollection AddServices(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddAutoMapper(typeof(DtoToDomainMapping));

            servicesCollection.TryAddScoped<IArticleService, ArticleService>();
            servicesCollection.TryAddScoped<IAuthorService, AuthorService>();
            servicesCollection.TryAddScoped<ICategoryService, CategoryService>();

            servicesCollection.TryAddScoped<IIdentityService, IdentityService>();

            return servicesCollection;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection servicesCollection)
        {
            servicesCollection.TryAddScoped<IArticleRepository, ArticleRepository>();
            servicesCollection.TryAddScoped<IAuthorRepository, AuthorRepository>();
            servicesCollection.TryAddScoped<ICategoryRepository, CategoryRepository>();

            return servicesCollection;
        }
    }
}
