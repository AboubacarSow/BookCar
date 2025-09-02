namespace BookCar.Application.Features.Mediator.Handlers.Blogs;


public class GetBlogsQueryHandler : IQueryHandler<GetBlogsQuery, List<GetBlogsQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetBlogsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<GetBlogsQueryResult>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        var blogs = (await _unitOfWork.BlogRepository.GetAllAsync(false))
            .Select(b => new GetBlogsQueryResult
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                ImageUrl = b.ImageUrl,
                CreatedAt = b.CreatedAt,
                UpdatedAt = b.UpdatedAt
            }).ToList();
        return blogs;
    }
}

public class GetBlogByIdQueryHandler : IQueryHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetBlogByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var blog = await _unitOfWork.BlogRepository.GetOneByIdAsync(request.Id, false)
         ?? throw new ArgumentException("Item does not found");
        return new GetBlogByIdQueryResult
        {
            Id = blog.Id,
            Title = blog.Title,
            Description = blog.Description,
            ImageUrl = blog.ImageUrl,
            CreatedAt = blog.CreatedAt,
            UpdatedAt = blog.UpdatedAt
        };
    }
}

public class CreateBlogCommandHandler : ICommandHandler<CreateBlogCommand, int>
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
            ImageUrl = request.ImageUrl,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        _unitOfWork.BlogRepository.Create(blog);
        await _unitOfWork.SaveChangesAsync();
        return blog.Id;
    }
}

public class UpdateBlogCommandHandler : ICommandHandler<UpdateBlogCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateBlogCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await _unitOfWork.BlogRepository.GetOneByIdAsync(request.Id, false)
         ?? throw new ArgumentException("Item does not found");
        blog.Title = request.Title;
        blog.Description = request.Description;
        blog.ImageUrl = request.ImageUrl;
        blog.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.BlogRepository.Update(blog);
        await _unitOfWork.SaveChangesAsync();
        return blog.Id;
    }
}

public class DeleteBlogCommandHandler : ICommandHandler<DeleteBlogCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteBlogCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.BlogRepository.RemoveByIdAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
        return request.Id;
    }
}