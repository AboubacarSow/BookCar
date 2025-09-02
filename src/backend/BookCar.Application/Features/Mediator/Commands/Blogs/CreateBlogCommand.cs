using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.Blogs;

public record CreateBlogCommand(string Title, 
    int AuthorId,
    string CoverImageUrl,
    int CategoryID,
    string Description)
 : IRequest<int>;
