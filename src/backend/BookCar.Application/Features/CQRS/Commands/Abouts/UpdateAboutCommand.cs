

namespace BookCar.Application.Features.CQRS.Commands.Abouts;

public class UpdateAboutCommand
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
