using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Data.Context;

namespace Infrastructure.Data.Repositories
{
    public class CategoryRepository: RepositoryBase<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
