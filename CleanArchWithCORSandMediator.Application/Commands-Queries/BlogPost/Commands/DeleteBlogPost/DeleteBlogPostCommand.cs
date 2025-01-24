using MediatR;

namespace CleanArchWithCORSandMediator.Application.Blogs.Commands.DeleteBlogPost
{
    public class DeleteBlogPostCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
