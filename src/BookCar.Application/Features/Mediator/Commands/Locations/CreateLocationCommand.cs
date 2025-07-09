namespace BookCar.Application.Features.Mediator.Commands.Locations;

public class CreateLocationCommand : IRequest
{
    public string Name { get; set; } 

}
public class UpdateLocationCommand : IRequest
{
    public int Id { get; set; } 
    public string Name { get; set; } 
}
public class DeleteLocationCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}