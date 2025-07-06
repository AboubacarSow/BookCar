namespace BookCar.Application.Features.CQRS.Results.Banners;

public class GetBannerQueryResult
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string VideoDescription { get; set; }
    public string VideoUrl { get; set; }

    // Additional properties can be added as needed
}
public class GetBannerByIdQueryResult
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string VideoDescription { get; set; }
    public string VideoUrl { get; set; }

    // Additional properties can be added as needed
}