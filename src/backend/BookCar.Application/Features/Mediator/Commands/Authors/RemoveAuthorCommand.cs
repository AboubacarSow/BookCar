using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.Authors;

public record RemoveAuthorCommand(int Id) : IRequest;

