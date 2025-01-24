using CleanArchWithCQRSandMediator.Domain.IReposiotry;
using MediatR;


namespace CleanArchWithCORSandMediator.Application.Blogs.Commands.DeleteBlogPost
{

    public class DeleteBlogPostCommandHandler : IRequestHandler<DeleteBlogPostCommand, bool>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        public DeleteBlogPostCommandHandler(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<bool> Handle(DeleteBlogPostCommand request, CancellationToken cancellationToken)
        {
            return await _blogPostRepository.DeleteBlogPostAsync(request.Id);
        }
    }
}
