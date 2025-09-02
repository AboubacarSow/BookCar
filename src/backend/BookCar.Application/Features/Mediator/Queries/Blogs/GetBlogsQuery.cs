namespace BookCar.Application.Features.Mediator.Queries.Blogs;

public record GetBlogsQuery : IQuery<List<GetBlogsQueryResult>>
{
}

public record GetBlogByIdQuery(int Id) : IQuery<GetBlogByIdQueryResult>
{
}