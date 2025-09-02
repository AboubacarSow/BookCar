using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.Blogs;

public record DeleteBlogCommand(int Id)
 : IRequest;