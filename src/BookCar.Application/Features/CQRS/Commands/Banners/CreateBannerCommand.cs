namespace BookCar.Application.Features.CQRS.Commands.Banners;
public class CreateBannerCommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string VideoDescription { get; set; }
    public string VideoUrl { get; set; }
    
    // Additional properties can be added as needed
}