using BookCar.Application.Features.Mediator.Results.SocialMedias;
using MediatR;

namespace BookCar.Application.Features.Mediator.Queries.SocialMedias;

public class GetSocialMediaByIdQuery(int id) : IRequest<GetSocialMediaByIdQueryResult>
{
    public int Id { get; set; } = id;
}