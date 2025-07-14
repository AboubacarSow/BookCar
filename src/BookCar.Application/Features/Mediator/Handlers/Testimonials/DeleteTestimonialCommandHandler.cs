using BookCar.Application.Features.Mediator.Commands.Testimonials;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Testimonials
{
    public class DeleteTestimonialCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteTestimonialCommand>
    {
        public async Task Handle(DeleteTestimonialCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Testimonial.RemoveByIdAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
