using CleanArchWithCORSandMediator.Application.Dto;
using CleanArchWithCQRSandMediator.Domain.Entity;
using CleanArchWithCQRSandMediator.Domain.Reposiotry;
using ClearArchWithSQRSandMediator.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ClearArchWithSQRSandMediator.Infra.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _blogDbContext;
        public BlogRepository(BlogDbContext blogDbContext) 
        {
            _blogDbContext = blogDbContext;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
           await  _blogDbContext.Blogs.AddAsync(blog);
           await  _blogDbContext.SaveChangesAsync();
            return blog;
        }
        public async Task<int> DeleteAsync(int id)
        {
            return await _blogDbContext.Blogs
                 .Where(model => model.Id == id)
                 .ExecuteDeleteAsync();
        }
        public async Task<List<Blog>> GetAllBlogAsync()
        {
           return await _blogDbContext.Blogs.ToListAsync();
        }
        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _blogDbContext.Blogs.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<int> UpdateAsync(int id, BlogDto blog)
        {
            return await _blogDbContext.Blogs
                 .Where(model => model.Id == id)
                 .ExecuteUpdateAsync(setters => setters
                 .SetProperty(m => m.Name, blog.Name)
                 .SetProperty(m => m.Description, blog.Description)
                 .SetProperty(m => m.Author, blog.Author)
                 );
        }
    }
}
