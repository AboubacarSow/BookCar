namespace BookCar.Application.Features.CQRS.Results.Cars;

public record GetCarQueryResult(int Id,int BrandID,string Model,
    string CoverImageUrl,int Km,string Transmission,byte Seat,
    byte Luggage,string Fuel,string BigImageUrl);

