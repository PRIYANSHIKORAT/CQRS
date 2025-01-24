using AutoMapper;
using CleanArchWithCORSandMediator.Application.Dto;
using CleanArchWithCQRSandMediator.Domain.Reposiotry;
using MediatR;

namespace CleanArchWithCORSandMediator.Application.Features.Blog.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogDto>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<BlogDto> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = new CleanArchWithCQRSandMediator.Domain.Entity.Blog
            {
                Name = request.Name,
                Description = request.Description,
                Author = request.Author
            };

            var result = await _blogRepository.CreateAsync(blogEntity);
            return _mapper.Map<BlogDto>(result);
        }
    }
}
