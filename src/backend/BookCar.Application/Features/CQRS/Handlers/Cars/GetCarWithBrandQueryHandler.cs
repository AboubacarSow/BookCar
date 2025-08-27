using BookCar.Application.Features.CQRS.Results.Cars;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Cars;

public class GetCarWithBrandQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;
    public GetCarWithBrandQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork= unitOfWork;
    }

    public async Task<List<GetCarWithBrandQueryResult>> Handle()
    {
        var cars = await _unitOfWork.Car.GetAllWithBrandAsync(false);
        return [.. cars.Select(c => new GetCarWithBrandQueryResult(c.Id,c.Brand?.Name, c.BrandID, c.Model,
            c.CoverImageUrl, c.Km, c.Transmission, c.Seat, c.Luggage,c.Fuel, c.BigImageUrl))];
    }
}

