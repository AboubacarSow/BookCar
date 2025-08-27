using BookCar.Application.Features.Mediator.Results.Testimonials;
using MediatR;

namespace BookCar.Application.Features.Mediator.Queries.Testimonials;

public class GetTestimonialByIdQuery(int id) : IRequest<GetTestimonialByIdQueryResult>
{
    public int Id { get; set; } = id;
}
