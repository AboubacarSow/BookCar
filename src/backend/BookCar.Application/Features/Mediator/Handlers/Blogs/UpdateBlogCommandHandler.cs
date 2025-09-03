using BookCar.Application.Features.Mediator.Commands.Blogs;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Blogs;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateBlogCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await _unitOfWork.Blog.GetOneByIdAsync(request.Id, false)
         ?? throw new ArgumentException("Item does not found");
        blog.Title = request.Title;
        blog.Description = request.Description;
        blog.CoverImageUrl = request.CoverImageUrl;
        blog.AuthorID = request.AuthorId;
        _unitOfWork.Blog.Update(blog);
        await _unitOfWork.SaveChangesAsync();
        return blog.Id;
    }
}
