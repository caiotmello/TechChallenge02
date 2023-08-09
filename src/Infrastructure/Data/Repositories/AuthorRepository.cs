using Domain.Core.Interface.Repositories;
using Domain.Models;

namespace Infrastructure.Data.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
