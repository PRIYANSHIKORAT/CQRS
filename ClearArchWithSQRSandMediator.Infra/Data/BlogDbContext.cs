using CleanArchWithCQRSandMediator.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClearArchWithSQRSandMediator.Infra.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
        : base(options)
        { }
        public DbSet<Blog> Blogs {  get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
