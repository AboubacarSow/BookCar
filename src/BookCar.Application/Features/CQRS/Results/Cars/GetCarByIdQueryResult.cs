namespace BookCar.Application.Features.CQRS.Results.Cars;

public  record GetCarByIdQueryResult(int Id,int BrandID,string Model,
    string CoverImageUrl,int Km,string Transmission,byte Seat,
    byte Luggage,string Fuel,string BigImageUrl);

