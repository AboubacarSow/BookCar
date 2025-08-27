using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.Services;

public class DeleteServiceCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}