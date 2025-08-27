using BookCar.Application.Features.Mediator.Queries.Services;
using BookCar.Application.Features.Mediator.Results.Services;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Services;

public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetServiceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
        var services = await _unitOfWork.Service.GetAllAsync(false);
        return [..services.Select(s => new GetServiceQueryResult(s.Id, s.Title, s.Description, s.IconUrl))];
        
    }
}
