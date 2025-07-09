namespace BookCar.Application.Features.Mediator.Queries.SocialMedias;

public class GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResult>>
{
}
public class GetSocialMediaByIdQuery(int id) : IRequest<GetSocialMediaByIdQueryResult>
{
    public int Id { get; set; } = id;
}