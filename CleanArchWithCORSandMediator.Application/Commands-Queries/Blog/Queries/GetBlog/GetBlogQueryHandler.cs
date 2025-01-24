using AutoMapper;
using CleanArchWithCORSandMediator.Application.Dto;
using CleanArchWithCQRSandMediator.Domain.Reposiotry;
using MediatR;

namespace CleanArchWithCORSandMediator.Application.Features.Blog.Queries.GetBlog
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogDto>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<List<BlogDto>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllBlogAsync();

            var blogList = _mapper.Map<List<BlogDto>>(blogs);
            return blogList;
        }
    }
}
