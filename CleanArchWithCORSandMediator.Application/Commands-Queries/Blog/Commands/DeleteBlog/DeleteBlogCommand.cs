using MediatR;

namespace CleanArchWithCORSandMediator.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommand : IRequest<int>
    { 
        public int Id { get; set; }
    }
}
