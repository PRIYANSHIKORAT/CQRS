using CleanArchWithCORSandMediator.Application.Blogs.Commands.DeleteBlog;
using CleanArchWithCORSandMediator.Application.Features.Blog.Commands.CreateBlog;
using CleanArchWithCORSandMediator.Application.Features.Blog.Commands.UpdateBlog;
using CleanArchWithCORSandMediator.Application.Features.Blog.Queries.GetBlog;
using CleanArchWithCORSandMediator.Application.Features.Blog.Queries.GetBlogById;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchWithCQRSandMediator.API.Controllers.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var blogs = await Mediator.Send(new GetBlogQuery());
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id });
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {
            var createBlog = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createBlog.Id }, createBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBlogCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteBlogCommand() { Id = id });
            return NoContent();
        }
    }
}