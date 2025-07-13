using MediatR;

namespace BookCar.Application.Features.Mediator;
public class DeleteTestimonialCommand(int id): IRequest{ public int Id { get; set; } = id; }
