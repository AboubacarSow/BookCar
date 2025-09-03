using BookCar.Application.Dtos;
using BookCar.Application.Features.Mediator.Queries.Blogs;
using BookCar.Application.Features.Mediator.Results.Blogs;
using BookCar.Application.Features.Mediator.Results.Comments;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Blogs;

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetBlogByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var blog = await _unitOfWork.Blog.GetOneByIdAsync(request.Id, false)
         ?? throw new ArgumentException("Item does not found");
        return new GetBlogByIdQueryResult
        {
            Id = blog.Id,
            Title = blog.Title,
            Description = blog.Description,
            CoverImageUrl = blog.CoverImageUrl,
            Author = new(blog.Author!.Id, blog.Author.Name, blog.Author.ImageUrl, blog.Author.Description),
            TagClouds = [.. blog.TagClouds.Select(t => new TagCloudDto(t.Title, t.BlogID))],
            Comments = [.. blog.Comments.Select(c => new GetCommentQueryResult(c.Id, c.Name, c.Description, c.CreatedDate, c.Email, c.Blog, c.BlogID))],
            Category = new(blog.CategoryID, blog.Category!.Name),
        };
    }
}
