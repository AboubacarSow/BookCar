namespace BookCar.MVC.Dtos.Abouts;

public record GetAboutDto(int Id,string Title,string Description,string ImageUrl);


public record CarWithBrandDto(int Id,string BrandName,int BrandID,string Model,
    string CoverImageUrl,int Km,string Transmission,byte Seat,
    byte Luggage,string Fuel,string BigImageUrl);
    
