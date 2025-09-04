using BookCar.Application.Features.Mediator.Commands.Authors;
using BookCar.Application.Features.Mediator.Queries.Authors;
using BookCar.Application.Features.Mediator.Results.Authors;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Authors;

public class CreateAuthorCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateAuthorCommand,int>
{

    public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = new Author
        {
            Name = request.Name,
            Description = request.Description,
            ImageUrl = request.ImageUrl,    
        };
        unitOfWork.Author.Create(author);
        await unitOfWork.SaveChangesAsync();
        return author.Id;
    }
}

public class UpdateAuthorCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateAuthorCommand>
{
    public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = new Author
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
        };
        unitOfWork.Author.Update(author);
        await unitOfWork.SaveChangesAsync();
    }
}

public class GetAuthorsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAuthorsQuery, List<GetAuthorQueryResult>>
{
    public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await unitOfWork.Author.GetAllAsync(false);
        return [.. authors.Select(a => new GetAuthorQueryResult(a.Id, a.Name, a.Description, a.ImageUrl))];
       
    }
}

public class GetAuthorByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
{
    public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author= await unitOfWork.Author.GetOneByIdAsync(request.Id,false);
        return new GetAuthorByIdQueryResult(author.Id,author.Name,author.Description,author.ImageUrl);  
    }
}
