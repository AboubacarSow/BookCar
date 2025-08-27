namespace BookCar.MVC.Dtos;

public record TestimonialDto(int Id,
            string Name,
             string Title,
             string Comment,
              string ImageUrl);

public record ContactInfoDto(int Id,
    string Address,
    string Email,
    string PhoneNumber);