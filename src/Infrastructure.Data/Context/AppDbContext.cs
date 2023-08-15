using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Article>()
                .HasOne(article => article.Author)
                .WithMany(author => author.Articles)
                .HasForeignKey(article => article.AuthorId);

            builder.Entity<Article>()
                .HasOne(article => article.Category)
                .WithMany(category => category.Articles)
                .HasForeignKey(article => article.CategoryId);

            //base.OnModelCreating(builder);
        }
    }
}
