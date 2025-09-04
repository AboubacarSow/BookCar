using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Commands.Authors;

public class CreateAuthorCommand:IRequest<int>
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}

