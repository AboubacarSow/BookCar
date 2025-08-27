using BookCar.Application.Features.Mediator.Queries.Services;
using BookCar.Application.Features.Mediator.Results.Services;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Services;

public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetServiceByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var service = await _unitOfWork.Service.GetOneByIdAsync(request.Id, false);
        if (service == null)
        {
            throw new KeyNotFoundException("Service not found.");
        }

        return new GetServiceByIdQueryResult(service.Id, service.Title, service.Description, service.IconUrl);
        
    }
}