using AutoMapper;
using CleanArchWithCORSandMediator.Application.Dto;
using CleanArchWithCQRSandMediator.Domain.Entity;
using CleanArchWithCQRSandMediator.Domain.IReposiotry;
using MediatR;


namespace CleanArchWithCORSandMediator.Application.Blogs.Commands.CreateBlogPost
{
    public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, BlogPostDto>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public CreateBlogPostCommandHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }
       
        public async Task<BlogPostDto> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
        {
            var BlogEntity = new BlogPost
            {
                Title = request.Title,
                Summary = request.Summary,
                Author = request.Auther,
                Description = request.Description,
                AuthorUrl = request.AuthorUrl,
                PublishDate = request.PublishDate
            };
            var result = await _blogPostRepository.CreateBlogPostAsync(BlogEntity);
            return _mapper.Map<BlogPostDto>(result);
        }
    }
}
