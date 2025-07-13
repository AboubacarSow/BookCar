using BookCar.Application.Features.Mediator.Commands.Testimonials;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Testimonials;

public class UpdateTestimonialCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateTestimonialCommand>
{
    public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var testimonial = new Testimonial
        {
            Id= request.Id,
            Name= request.Name,
            Title= request.Title,
            Comment= request.Comment,
            ImageUrl= request.ImageUrl
        };
        _unitOfWork.Testimonial.Update(testimonial);
        await _unitOfWork.SaveChangesAsync();   
    }
}
