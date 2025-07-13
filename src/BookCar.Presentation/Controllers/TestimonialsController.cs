using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.Presentation.Controllers;

[ApiController]
[Route("api/testimonials")]
public class TestimonialsController(IMediator _mediator): ControllerBase
{

}
