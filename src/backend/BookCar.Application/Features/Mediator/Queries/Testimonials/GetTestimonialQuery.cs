using BookCar.Application.Features.Mediator.Results.Testimonials;
using MediatR;

namespace BookCar.Application.Features.Mediator.Queries.Testimonials;
public class GetTestimonialQuery: IRequest<List<GetTestimonialQueryResult>>
{
}
