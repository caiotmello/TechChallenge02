using Domain.Core.Interface.Repositories;
using Domain.Models;

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
