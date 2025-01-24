using MediatR;

namespace CleanArchWithCORSandMediator.Application.Blogs.Commands.UpdateBlogPost
{
    public record class UpdateBlogPostCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Summary { get; set; }

        public string? Description { get; set; }

        public string? Author { get; set; }

        public string? AuthorUrl { get; set; }
    }
}
