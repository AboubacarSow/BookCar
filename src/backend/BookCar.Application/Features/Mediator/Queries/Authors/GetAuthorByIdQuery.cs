using BookCar.Application.Features.Mediator.Results.Authors;
using MediatR;

namespace BookCar.Application.Features.Mediator.Queries.Authors;

public record GetAuthorByIdQuery:IRequest<GetAuthorByIdQueryResult>;

