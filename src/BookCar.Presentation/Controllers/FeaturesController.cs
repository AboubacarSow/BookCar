using BookCar.Application.Features.Mediator.Commands.Features;
using BookCar.Application.Features.Mediator.Queries.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.Presentation.Controllers;

[Route("api/features")]
[ApiController]
public class FeaturesController : ControllerBase
{
    private readonly IMediator _mediator;
    public FeaturesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mediator.Send(new GetFeatureQuery());
        return Ok(values);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var value = await _mediator.Send(new GetFeatureByIdQuery(id));
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateFeatureCommand command)
    {
        await _mediator.Send(command);
        return Ok("Özellik başarıyla eklendi");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        await _mediator.Send(new RemoveFeatureCommand(id));
        return Ok("Özellik başarıyla silindi");
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdateFeatureCommand command)
    {
        await _mediator.Send(command);
        return Ok("Özellik başarıyla güncellendi");
    }
}
