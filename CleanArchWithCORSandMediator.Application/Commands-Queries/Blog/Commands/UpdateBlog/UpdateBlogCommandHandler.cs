using CleanArchWithCORSandMediator.Application.Dto;
using CleanArchWithCQRSandMediator.Domain.Reposiotry;
using MediatR;

namespace CleanArchWithCORSandMediator.Application.Features.Blog.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var UpdateBlogEntity = new BlogDto
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Author = request.Author,
            };
            return await _blogRepository.UpdateAsync(request.Id, UpdateBlogEntity);
        }
    }
}
