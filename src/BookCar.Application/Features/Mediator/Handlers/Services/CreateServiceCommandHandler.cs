using BookCar.Application.Features.Mediator.Commands.Services;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Services;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = new Domain.Entities.Service
        {
            Title = request.Title,
            Description = request.Description,
            IconUrl = request.IconUrl
        };

        _unitOfWork.Service.Create(service);
        await _unitOfWork.SaveChangesAsync();

    }
}
