﻿using MediatR;

namespace CleanArchWithCORSandMediator.Application.Features.Blog.Commands.UpdateBlog
{
    public class UpdateBlogCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
    }
}
