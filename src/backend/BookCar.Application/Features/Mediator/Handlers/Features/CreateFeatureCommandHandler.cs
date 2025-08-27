using BookCar.Application.Features.Mediator.Commands.Features;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookCar.Application.Features.Mediator.Handlers.Features;

public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateFeatureCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {

         _unitOfWork.Feature.Create(new Feature { Name = request.Name });
        await _unitOfWork.SaveChangesAsync();
    }
}
public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFeatureCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.Feature.Update(new Feature {Id=request.Id, Name = request.Name });
        await _unitOfWork.SaveChangesAsync();
    }
}
public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveFeatureCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Feature.RemoveByIdAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();   
    }
}
