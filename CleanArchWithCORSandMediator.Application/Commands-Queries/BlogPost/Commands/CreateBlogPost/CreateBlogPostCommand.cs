using CleanArchWithCORSandMediator.Application.Dto;
using MediatR;


namespace CleanArchWithCORSandMediator.Application.Blogs.Commands.CreateBlogPost
{
    public record class CreateBlogPostCommand : IRequest<BlogPostDto>
    {
        public required string Title { get; set; }
        public required string Summary { get; set; }
        public required string Auther { get; set; }
        public DateTime? PublishDate { get; set; }
        public string? Description { get; set; }
        public string? AuthorUrl { get; set; }
    }
}
