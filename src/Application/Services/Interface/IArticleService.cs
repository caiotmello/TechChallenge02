using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface IArticleService
    {
        Task<ResultService<ReadArticleDto>> CreateAsync(CreateArticleDto ArticleDto);
        Task<ResultService<ICollection<ReadArticleDto>>> GetAsync();
        Task<ResultService<ReadArticleDto>> GetByIdAsync(int Id);
        Task<ResultService> UpdateAsync(UpdateArticleDto articleDto);
        Task<ResultService> DeleteAsync(int Id);
    }
}
