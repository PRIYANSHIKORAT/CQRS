using CleanArchWithCORSandMediator.Application.Dto;
using CleanArchWithCQRSandMediator.Domain.IReposiotry;
using MediatR;

namespace CleanArchWithCORSandMediator.Application.Blogs.Commands.UpdateBlogPost
{
    public class UpdateBlogPostCommandHandler : IRequestHandler<UpdateBlogPostCommand, int>
    {

        private readonly IBlogPostRepository _blogPostRepository;

        public UpdateBlogPostCommandHandler(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<int> Handle(UpdateBlogPostCommand request, CancellationToken cancellationToken)
        {
            var UpdateBlogEntity = new BlogPostDto
            {
                Title = request.Title,
                Summary = request.Summary,
                Description = request.Description,
                Author = request.Author,
                AuthorUrl = request.AuthorUrl,
            };
            return await _blogPostRepository.UpdateBlogPostAsync(request.Id, UpdateBlogEntity);
 
        }
    }
}
