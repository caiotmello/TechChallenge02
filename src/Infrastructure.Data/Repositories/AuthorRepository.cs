using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Data.Context;

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
