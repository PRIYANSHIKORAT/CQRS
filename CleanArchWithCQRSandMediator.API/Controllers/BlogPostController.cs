using CleanArchWithCORSandMediator.Application.Blogs.Commands.CreateBlogPost;
using CleanArchWithCORSandMediator.Application.Blogs.Commands.DeleteBlogPost;
using CleanArchWithCORSandMediator.Application.Blogs.Commands.UpdateBlogPost;
using CleanArchWithCORSandMediator.Application.Blogs.Queries.GetBlogPost;
using CleanArchWithCORSandMediator.Application.Blogs.Queries.GetBlogPostById;
using CleanArchWithCQRSandMediator.API.Controllers.Blog;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchWithCQRSandMediator.API.Controllers
{
    namespace CleanArchWithCQRSandMediator.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class BlogPostController : ApiControllerBase
        {
            [HttpGet]
            public async Task<IActionResult> GetAllAsync()
            {
                var blogposts = await Mediator.Send(new GetBlogPostQuery());
                return Ok(blogposts);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var blogposts = await Mediator.Send(new GetBlogPostByIdQuery() { BlogPostId = id });
                if (blogposts == null)
                {
                    return NotFound();
                }
                return Ok(blogposts);
            }

            [HttpPost]
            public async Task<IActionResult> Create(CreateBlogPostCommand command)
            {
                var createBlogpost = await Mediator.Send(command);
                return CreatedAtAction(nameof(GetById), new { id = createBlogpost.Id, Autor = createBlogpost.Author, Description = createBlogpost.Description, Title = createBlogpost.Title }, createBlogpost);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, UpdateBlogPostCommand command)
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
                await Mediator.Send(new DeleteBlogPostCommand() { Id = id });
                return NoContent();
            }
        }
    }
}