using BookCar.Application.Features.Mediator.Commands.Authors;
using BookCar.Application.Features.Mediator.Queries.Authors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.Presentation.Controllers;

[ApiController]
[Route("api/authors")]
public class AuthorsController(IMediator _mediator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var authors = await _mediator.Send(new GetAuthorsQuery());
        return Ok(authors);
    }
    [HttpGet("{id}")]
    public async  Task<IActionResult> GetById(int id)
    {
        var author = await _mediator.Send(new GetAuthorByIdQuery(id));
        return Ok(author);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAuthorCommand command)
    {
        var authorId= await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = authorId }, null);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAuthorCommand command)
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
        await _mediator.Send(new RemoveAuthorCommand(id));
        return NoContent();
    }
}