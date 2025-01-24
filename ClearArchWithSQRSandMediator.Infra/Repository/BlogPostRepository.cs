using CleanArchWithCORSandMediator.Application.Dto;
using CleanArchWithCQRSandMediator.Domain.Entity;
using CleanArchWithCQRSandMediator.Domain.IReposiotry;
using ClearArchWithSQRSandMediator.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearArchWithSQRSandMediator.Infra.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogPostRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public async Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost)
        {
            await _blogDbContext.BlogPosts.AddAsync(blogPost);
            await _blogDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteBlogPostAsync(int id)
        {
            var blogPost = await _blogDbContext.BlogPosts.FindAsync(id);
            if (blogPost == null)
                return false;

            _blogDbContext.BlogPosts.Remove(blogPost);
            await _blogDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<BlogPost>> GetAllBlogPostAsync()
        {
            return await _blogDbContext.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost?> GetBlogPostByIdAsync(int id)
        {
            return await _blogDbContext.BlogPosts.FindAsync(id);
                //.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateBlogPostAsync(int id, BlogPostDto blogPost)
        {
            return await _blogDbContext.BlogPosts
                .Where(bp => bp.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(bp => bp.Title, blogPost.Title)
                    .SetProperty(bp => bp.Summary, blogPost.Summary)
                    .SetProperty(bp => bp.Description, blogPost.Description)
                    .SetProperty(bp => bp.Author, blogPost.Author)
                    .SetProperty(bp => bp.AuthorUrl, blogPost.AuthorUrl)
                );
        }
    }
}
