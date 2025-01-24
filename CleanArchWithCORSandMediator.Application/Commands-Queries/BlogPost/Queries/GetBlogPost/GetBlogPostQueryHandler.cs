using AutoMapper;
using CleanArchWithCORSandMediator.Application.Dto;
using CleanArchWithCQRSandMediator.Domain.IReposiotry;
using MediatR;


namespace CleanArchWithCORSandMediator.Application.Blogs.Queries.GetBlogPost
{
    public class GetBlogPostQueryHandler : IRequestHandler<GetBlogPostQuery, List<BlogPostDto>>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;
        public GetBlogPostQueryHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }
        public async Task<List<BlogPostDto>> Handle(GetBlogPostQuery request, CancellationToken cancellationToken)
        {
            var blogposts = await _blogPostRepository.GetAllBlogPostAsync();

            var blogList = _mapper.Map<List<BlogPostDto>>(blogposts);
            return blogList;
        }
    }
}
