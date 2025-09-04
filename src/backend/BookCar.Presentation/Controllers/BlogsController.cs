using BookCar.Application.Features.Mediator.Commands.Blogs;
using BookCar.Application.Features.Mediator.Queries.Blogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookCar.Presentation.Controllers;

[ApiController]
[Route("api/blogs")]
public class BlogsController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var blogs = await _mediator.Send(new GetBlogsQuery());
        return Ok(blogs);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var blog =await  _mediator.Send(new GetBlogByIdQuery(id));
        return Ok(blog);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBlogCommand command)
    {
        var blogId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = blogId }, null);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBlogCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("ID mismatch");
        }
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteBlogCommand(id));
        return NoContent();
    }
    [HttpGet("lastThreeblogs")]
    public async Task<IActionResult> GetLastThreeBlogs()
    {
        var blogs = await _mediator.Send(new GetThreeLastBlogsQuery());
        return Ok(blogs);
    }
}
