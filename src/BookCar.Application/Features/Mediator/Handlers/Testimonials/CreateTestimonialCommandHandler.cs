using BookCar.Application.Features.Mediator.Commands.Testimonials;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Testimonials;

public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTestimonialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork=unitOfWork;
    }

    public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var testimonial = new Testimonial
        {
            Name = request.Name,
            Title = request.Title,  
            Comment = request.Comment,
            ImageUrl = request.ImageUrl,
        };
         _unitOfWork.Testimonial.Create(testimonial);
        await _unitOfWork.SaveChangesAsync();
    }
}