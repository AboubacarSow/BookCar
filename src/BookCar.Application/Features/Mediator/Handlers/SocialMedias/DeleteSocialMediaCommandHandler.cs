using BookCar.Application.Features.Mediator.Commands.SocialMedias;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.SocialMedias;

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
