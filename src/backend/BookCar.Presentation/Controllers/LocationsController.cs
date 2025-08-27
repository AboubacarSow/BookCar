using BookCar.Application.Features.Mediator.Commands.Locations;
using BookCar.Application.Features.Mediator.Queries.Locations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.Presentation.Controllers;

[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    private readonly IMediator _mediator;
    public LocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetLocationQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetLocationByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateLocationCommand command)
    {
        await _mediator.Send(command);
        return Ok(new {Message="Lokasyon başarıyla eklendi"});
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteLocationCommand(id));
        return Ok(new {Message="Lokasyon başarıyla silindi"});
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdateLocationCommand command)
    {
        await _mediator.Send(command);
        return Ok( new {Message="Lokasyon başarıyla güncellendi"});
    }
}
