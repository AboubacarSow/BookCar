namespace BookCar.Application.Features.Mediator.Results.Services;

public class GetServiceQueryResult(int id, string title, string description, string iconUrl)
{
    public int Id { get; set; } = id;
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public string IconUrl { get; set; } = iconUrl;

}
public class GetServiceByIdQueryResult(int id, string title, string description, string iconUrl)
{
    public int Id { get; set; } = id;
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public string IconUrl { get; set; } = iconUrl;
}
