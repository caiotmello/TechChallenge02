using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Data.Context;

namespace Infrastructure.Data.Repositories
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        private readonly AppDbContext _context;
        public ArticleRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
