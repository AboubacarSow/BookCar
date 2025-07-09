namespace BookCar.Application.Features.Mediator.Results.SocialMedias;

public class GetSocialMediaQueryResult(int id, string name, string iconUrl, string link)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Url { get; set; } = url;
    public string Icon { get; set; } = icon;
}
public class GetSocialMediaByIdQueryResult(int id, string name, string iconUrl, string link)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Url { get; set; } = url;
    public string Icon { get; set; } = icon;
}