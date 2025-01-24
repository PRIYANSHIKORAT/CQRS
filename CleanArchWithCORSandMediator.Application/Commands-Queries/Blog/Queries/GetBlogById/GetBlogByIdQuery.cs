using CleanArchWithCORSandMediator.Application.Dto;
using MediatR;

namespace CleanArchWithCORSandMediator.Application.Features.Blog.Queries.GetBlogById
{
    public class GetBlogByIdQuery : IRequest<BlogDto>
    {
        public int BlogId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Author { get; set; }
    }
}
