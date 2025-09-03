using BookCar.Domain.Entities;

namespace BookCar.Application.Features.Mediator.Results.Comments;

public  record GetCommentQueryResult(int Id,string Name,string Description,DateTime CreatedDate,string Email,Blog? Blog,int BlogID);

