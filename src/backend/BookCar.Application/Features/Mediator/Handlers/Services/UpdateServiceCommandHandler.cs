using BookCar.Application.Features.Mediator.Commands.Services;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Services;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _unitOfWork.Service.GetOneByIdAsync(request.Id, false);
        service.Title = request.Title;
        service.Description = request.Description;
        service.IconUrl = request.IconUrl;

        _unitOfWork.Service.Update(service);
        await _unitOfWork.SaveChangesAsync();
    }
}
