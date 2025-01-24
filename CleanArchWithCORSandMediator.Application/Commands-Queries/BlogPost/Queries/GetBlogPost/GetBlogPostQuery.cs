using CleanArchWithCORSandMediator.Application.Dto;
using MediatR;

namespace CleanArchWithCORSandMediator.Application.Blogs.Queries.GetBlogPost
{
    public record class GetBlogPostQuery : IRequest<List<BlogPostDto>>
    {

    }
}