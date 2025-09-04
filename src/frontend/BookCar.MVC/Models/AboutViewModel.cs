namespace BookCar.MVC.Models;

internal record AboutViewModel()
{
    public AboutInfo AboutInfo { get; init; } = new();
    public List<TestimonialDto> Testimonials { get; init; } = [];

    public StatisticViewModel Statistics { get; init; } = new();
}
public  record StatisticViewModel
{
    public int YearsOfExperience { get; init; } = 60;
    public int TotalCars { get; init; } = 1090;
    public int HappyCustomers { get; init; } = 2590;
    public int TotalBranches { get; init; } = 67;
}
public class IndexViewModel
{
    public AboutInfo AboutInfo { get; set; } = new();
    public List<HizmetDto> Hizmetler { get; init; } = [];

    public List<TestimonialDto> Testimonials { get; init; } = [];

    public StatisticViewModel Statistics { get; set; } = new();
}

public class AboutInfo
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}

public class BlogFeatureViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public int CommentCount { get; set; }
}

