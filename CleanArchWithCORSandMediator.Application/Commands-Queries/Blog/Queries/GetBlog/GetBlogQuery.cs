using CleanArchWithCORSandMediator.Application.Dto;
using MediatR;

namespace CleanArchWithCORSandMediator.Application.Features.Blog.Queries.GetBlog
{
    public class GetBlogQuery : IRequest<List<BlogDto>>
    {

    }
}