namespace BookCar.MVC.Models;

internal record AboutViewModel(int Id,
 string Title,
 string Description,
  string ImageUrl
)
{
    public List<TestimonialDto> Testimonials { get; init; } = [];

    public StatisticViewModel Statistics { get; init; } = new();
}
internal record StatisticViewModel
{
    public int YearsOfExperience { get; init; } = 60;
    public int TotalCars { get; init; } = 1090;
    public int HappyCustomers { get; init; } = 2590;
    public int TotalBranches { get; init; } = 67;
}

