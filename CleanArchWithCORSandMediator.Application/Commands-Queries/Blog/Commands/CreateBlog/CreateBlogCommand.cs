using CleanArchWithCORSandMediator.Application.Dto;
using MediatR;

namespace CleanArchWithCORSandMediator.Application.Features.Blog.Commands.CreateBlog
{
    public class CreateBlogCommand : IRequest<BlogDto>
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string Author { get; set; }
    }
}
