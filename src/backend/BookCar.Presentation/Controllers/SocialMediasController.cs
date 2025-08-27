using BookCar.Application.Features.Mediator.Commands.SocialMedias;
using BookCar.Application.Features.Mediator.Queries.SocialMedias;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.Presentation.Controllers;

[ApiController]
[Route("api/socialmedias")]
public class SocialMediasController : ControllerBase
{
    private readonly IMediator _mediator;

    public SocialMediasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetSocialMediaQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetSocialMediaByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSocialMediaCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Message = "Sosyal Medya başarıyla eklendi" });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteSocialMediaCommand(id));
        return Ok(new { Message = "Sosyal Medya başarıyla silindi" });
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateSocialMediaCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Message = "Sosyal Medya başarıyla güncellendi" });
    }
}
