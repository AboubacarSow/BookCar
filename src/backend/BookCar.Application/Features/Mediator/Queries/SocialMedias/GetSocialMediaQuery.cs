using BookCar.Application.Features.Mediator.Results.SocialMedias;
using MediatR;

namespace BookCar.Application.Features.Mediator.Queries.SocialMedias;

public class GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResult>>
{
}
