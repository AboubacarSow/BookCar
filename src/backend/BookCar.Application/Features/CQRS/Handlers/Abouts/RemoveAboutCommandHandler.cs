

using BookCar.Application.Features.CQRS.Commands.Abouts;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Abouts;

public  class RemoveAboutCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;
    public RemoveAboutCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(RemoveAboutCommand request)
    {
       await _unitOfWork.About.RemoveByIdAsync(request.Id);
       await _unitOfWork.SaveChangesAsync();
       return true; 
    }
}
