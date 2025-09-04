using BookCar.Application.Dtos;
using BookCar.Application.Features.Mediator.Queries.Blogs;
using BookCar.Application.Features.Mediator.Results.Blogs;
using BookCar.Application.Features.Mediator.Results.Comments;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Blogs;
public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, List<GetBlogsQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetBlogsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<GetBlogsQueryResult>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        var blogs = (await _unitOfWork.Blog.GetAllAsync(false))
            .Select(b => new GetBlogsQueryResult
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                CoverImageUrl = b.CoverImageUrl,
                Author = new(b.Author!.Id,b.Author.Name,b.Author.ImageUrl,b.Author.Description),
                TagClouds=b.TagClouds.Select(t=>new TagCloudDto(t.Title,t.BlogID)).ToList(),
                Comments=b.Comments
                .Select(c=>new GetCommentQueryResult(c.Id,c.Name,c.Description,c.CreatedDate,c.Email,c.Blog,c.BlogID)).ToList(),
                Category= new(b.CategoryID,b.Category!.Name),

            }).ToList();
        return blogs;
    }
}
public class GetThreeLasteBlogsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetThreeLastBlogsQuery, List<GetThreeLastBlogsQueryResult>>
{
    public async Task<List<GetThreeLastBlogsQueryResult>> Handle(GetThreeLastBlogsQuery request, CancellationToken cancellationToken)
    {
        var blogs = (await _unitOfWork.Blog.GetThreeLastBlogsAsync(false))
            .Select(b => new GetThreeLastBlogsQueryResult(
                b.Id,
                b.Title,
                new(b.Author!.Id,b.Author.Name,b.Author.ImageUrl,b.Author.Description),
                b.CoverImageUrl,
                b.CreatedDate,
                new(b.Category!.Id,b.Category.Name),
                b.Description,
                b.TagClouds.Select(t => new TagCloudDto(t.Title, t.BlogID)).ToList(),
                [.. b.Comments.Select(c => new GetCommentQueryResult(c.Id, c.Name, c.Description, c.CreatedDate, c.Email, c.Blog, c.BlogID))]
                )).ToList();
        return blogs;
    }
}
