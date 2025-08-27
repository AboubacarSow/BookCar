using BookCar.Application.Features.Mediator.Commands.Testimonials;
using BookCar.Application.Features.Mediator.Queries.Testimonials;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.Presentation.Controllers;

[ApiController]
[Route("api/testimonials")]
public class TestimonialsController(IMediator _mediator): ControllerBase
{
   
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mediator.Send(new GetTestimonialQuery());
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTestimonial(int id)
    {
        var value = await _mediator.Send(new GetTestimonialByIdQuery(id));
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
    {
        await _mediator.Send(command);
        return Ok("Referans başarıyla eklendi");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveTestimonial(int id)
    {
        await _mediator.Send(new DeleteTestimonialCommand(id));
        return Ok("Referans başarıyla silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
    {
        await _mediator.Send(command);
        return Ok("Referans başarıyla güncellendi");
    }
}
