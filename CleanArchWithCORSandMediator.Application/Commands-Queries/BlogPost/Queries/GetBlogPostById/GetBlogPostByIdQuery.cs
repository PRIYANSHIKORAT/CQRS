using CleanArchWithCORSandMediator.Application.Dto;
using MediatR;

namespace CleanArchWithCORSandMediator.Application.Blogs.Queries.GetBlogPostById
{
    public record class GetBlogPostByIdQuery : IRequest<BlogPostDto>
    {
        public int BlogPostId { get; set; }
    }
}
