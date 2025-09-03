using BookCar.Application.Features.Mediator.Commands.Blogs;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Blogs;

public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteBlogCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Blog.RemoveByIdAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
        return request.Id;
    }
}