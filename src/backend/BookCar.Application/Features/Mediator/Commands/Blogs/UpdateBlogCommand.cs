using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.Blogs;

public record UpdateBlogCommand(int Id, 
     string Title,
     int AuthorId, 
     string CoverImageUrl,
     int CategoryID,
     string Description)
 : IRequest<int>;
