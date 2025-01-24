using CleanArchWithCORSandMediator.Application.Dto;
using CleanArchWithCQRSandMediator.Domain.Entity;

namespace CleanArchWithCQRSandMediator.Domain.Reposiotry
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogAsync();
        Task<Blog?> GetByIdAsync(int id);
        Task<Blog> CreateAsync(Blog blog);
        Task<int> UpdateAsync(int id, BlogDto blog);
        Task<int> DeleteAsync(int id);
    }
}
