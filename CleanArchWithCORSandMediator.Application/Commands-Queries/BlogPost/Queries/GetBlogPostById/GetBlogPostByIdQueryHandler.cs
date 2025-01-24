using AutoMapper;
using CleanArchWithCORSandMediator.Application.Dto;
using CleanArchWithCQRSandMediator.Domain.IReposiotry;
using MediatR;

namespace CleanArchWithCORSandMediator.Application.Blogs.Queries.GetBlogPostById
{
    public class GetBlogPostByIdQueryHandler : IRequestHandler<GetBlogPostByIdQuery, BlogPostDto>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public GetBlogPostByIdQueryHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }
        public async Task<BlogPostDto> Handle(GetBlogPostByIdQuery request, CancellationToken cancellationToken)
        {
            var blogpost = await _blogPostRepository.GetBlogPostByIdAsync(request.BlogPostId);
            return _mapper.Map<BlogPostDto>(blogpost);
        }
    }
}
