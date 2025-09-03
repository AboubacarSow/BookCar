using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Commands.Authors;

public class CreateAuthorCommand:IRequest
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}

public class UpdateAuthorCommand:IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}

public record RemoveAuthorCommand(int Id) : IRequest;

