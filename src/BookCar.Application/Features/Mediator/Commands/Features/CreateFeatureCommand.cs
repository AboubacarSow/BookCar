using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.Features;

public class CreateFeatureCommand :IRequest
{
    public string Name { get; set; }
}
public class UpdateFeatureCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class RemoveFeatureCommand(int id): IRequest
{
    public int Id { get; set; } = id;
}
