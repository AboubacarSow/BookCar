using BookCar.Application.Features.CQRS.Commands.Cars;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;

namespace BookCar.Application.Features.CQRS.Handlers.Cars;

public class UpdateCarCommandHandler 
{ 
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCarCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCarCommand request)
    {
        var car = new Car
        {
            Id=request.Id,
            BrandID = request.BrandID,
            Model = request.Model,
            CoverImageUrl = request.CoverImageUrl,
            Km = request.Km,
            Transmission = request.Transmission,
            Seat = request.Seat,
            Luggage = request.Luggage,
            Fuel = request.Fuel,
            BigImageUrl = request.BigImageUrl
        };
        _unitOfWork.Car.Create(car);
        await _unitOfWork.SaveChangesAsync();
    }
   
}

