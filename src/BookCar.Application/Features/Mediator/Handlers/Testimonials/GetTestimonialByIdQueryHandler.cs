using BookCar.Application.Features.Mediator.Queries.Testimonials;
using BookCar.Application.Features.Mediator.Results.Testimonials;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Testimonials;

public class GetTestimonialByIdQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
{
    public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
    {
        var testimonial = await _unitOfWork.Testimonial.GetOneByIdAsync(request.Id,false);
        return new GetTestimonialByIdQueryResult(testimonial.Id, testimonial.Name, testimonial.Title,testimonial.Comment, testimonial.ImageUrl);
    }
}
