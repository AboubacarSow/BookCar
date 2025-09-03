using BookCar.Application.Features.Mediator.Results.Authors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Queries.Authors;

public record GetAuthorsQuery:IRequest<List<GetAuthorQueryResult>>;

