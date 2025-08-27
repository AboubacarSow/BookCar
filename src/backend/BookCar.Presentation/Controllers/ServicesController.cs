using BookCar.Application.Features.Mediator.Commands.Services;
using BookCar.Application.Features.Mediator.Queries.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.Presentation.Controllers;

[ApiController]
[Route("api/services")]
public class ServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetServiceQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetServiceByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Message = "Hizmet başarıyla eklendi" });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteServiceCommand(id));
        return Ok(new { Message = "Hizmet başarıyla silindi" });
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateServiceCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Message = "Hizmet başarıyla güncellendi" });
    }

}
