using BookCar.Application.Features.Mediator.Commands.Pricings;
using BookCar.Application.Features.Mediator.Queries.Pricings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.Presentation.Controllers;

[ApiController]
[Route("api/pricings")]
public class PricingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PricingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetPricingQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetPricingByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePricingCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Message = "Ödeme Türü başarıyla eklendi" });
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeletePricingCommand(id));
        return Ok(new { Message = "Ödeme Türü başarıyla silindi" });
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdatePricingCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Message = "Ödeme Türü başarıyla güncellendi" });
    }
}
