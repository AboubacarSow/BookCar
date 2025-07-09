namespace BookCar.Application.Features.Mediator.Handlers.SocialMedias;

public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSocialMediaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var socialMedia = new Domain.Entities.SocialMedia
        {
            Name = request.Name,
            Url = request.Url,
            IconUrl = request.IconUrl
        };

        _unitOfWork.SocialMedia.Create(socialMedia);
        await _unitOfWork.SaveChangesAsync();

    }
}
public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSocialMediaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var socialMedia = await _unitOfWork.SocialMedia.GetByIdAsync(request.Id);
        if (socialMedia == null)
        {
            throw new KeyNotFoundException("Social media not found.");
        }

        socialMedia.Name = request.Name;
        socialMedia.Url = request.Url;
        socialMedia.IconUrl = request.IconUrl;

        _unitOfWork.SocialMedia.Update(socialMedia);
        await _unitOfWork.SaveChangesAsync();
    }
}
public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSocialMediaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.SocialMedia.RemoveByIdAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSocialMediaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
    {
        var socialMedias = await _unitOfWork.SocialMedia.GetAllAsync();
        return socialMedias.Select(sm => new GetSocialMediaQueryResult
        {
            Id = sm.Id,
            Name = sm.Name,
            Url = sm.Url,
            IconUrl = sm.IconUrl
        }).ToList();
    }
}
public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSocialMediaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
    {
        var socialMedia = await _unitOfWork.SocialMedia.GetByIdAsync(request.Id);
        if (socialMedia == null)
        {
            throw new KeyNotFoundException("Social media not found.");
        }

        return new GetSocialMediaByIdQueryResult
        {
            Id = socialMedia.Id,
            Name = socialMedia.Name,
            Url = socialMedia.Url,
            IconUrl = socialMedia.IconUrl
        };
    }
}