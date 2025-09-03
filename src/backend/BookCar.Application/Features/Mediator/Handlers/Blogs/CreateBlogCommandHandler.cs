using BookCar.Application.Features.Mediator.Commands.Blogs;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Blogs;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateBlogCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = new Blog
        {
            Title = request.Title,
            Description = request.Description,
            CoverImageUrl = request.CoverImageUrl,
            AuthorID=request.AuthorId,
            CategoryID=request.CategoryID,
        };
        _unitOfWork.Blog.Create(blog);
        await _unitOfWork.SaveChangesAsync();
        return blog.Id;


    }
}
