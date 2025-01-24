using CleanArchWithCORSandMediator.Application.Dto;
using CleanArchWithCQRSandMediator.Domain.Entity;

namespace CleanArchWithCQRSandMediator.Domain.IReposiotry
{
    public interface IBlogPostRepository
    {
        Task<List<BlogPost>> GetAllBlogPostAsync();
        Task<BlogPost?> GetBlogPostByIdAsync(int id);
        Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost);
        Task<int> UpdateBlogPostAsync(int id, BlogPostDto blogPost);
        Task<bool> DeleteBlogPostAsync(int id);
    }
}
