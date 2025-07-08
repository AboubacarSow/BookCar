using BookCar.Application.Features.CQRS.Queries.Cars;
using BookCar.Application.Features.CQRS.Results.Cars;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Cars;

public class GetCarByIdQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;
    public GetCarByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request)
    {
        var car= await _unitOfWork.Car.GetOneByIdAsync(request.Id,false);
        return new GetCarByIdQueryResult(car.Id, car.Id, car.Model, car.CoverImageUrl, car.Km, 
            car.Transmission, car.Seat, car.Luggage, car.Fuel, car.BigImageUrl);
    }
}

