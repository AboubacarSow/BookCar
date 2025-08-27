using BookCar.Application.Features.Mediator.Queries.Testimonials;
using BookCar.Application.Features.Mediator.Results.Testimonials;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Testimonials;
public class GetTestimonialQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
{
    public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
    {
        var testimonials = await _unitOfWork.Testimonial.GetAllAsync(false);
        return [.. testimonials.Select
            (testimonial => new GetTestimonialQueryResult(testimonial.Id, testimonial.Name, testimonial.Title, testimonial.Comment, testimonial.ImageUrl))];
    }
}
