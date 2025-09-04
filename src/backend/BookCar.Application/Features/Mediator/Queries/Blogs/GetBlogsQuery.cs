using BookCar.Application.Features.Mediator.Results.Blogs;
using MediatR;

namespace BookCar.Application.Features.Mediator.Queries.Blogs;

public record GetBlogsQuery : IRequest<List<GetBlogsQueryResult>>;
public record GetBlogByIdQuery(int Id) : IRequest<GetBlogByIdQueryResult>;
public record GetThreeLastBlogsQuery:IRequest<List<GetThreeLastBlogsQueryResult>>;