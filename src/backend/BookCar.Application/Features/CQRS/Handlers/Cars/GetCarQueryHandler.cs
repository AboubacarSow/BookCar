using BookCar.Application.Features.CQRS.Results.Cars;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Cars;

public class GetCarQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;
    public GetCarQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<GetCarQueryResult>> Handle()
    {
       var cars=await _unitOfWork.Car.GetAllAsync(false);
        return [.. cars.Select(c=> new GetCarQueryResult(c.Id,c.BrandID,c.Model,c.CoverImageUrl,c.Km,c.Transmission,c.Seat,c.Luggage,
            c.Fuel,c.BigImageUrl))];
    }
}

