namespace BookCar.Application.Features.Mediator.Commands.Services;

public class CreateServiceCommand : IRequest
{
    public string Title { get; set; } 
    public string Description { get; set; }  
    public string IconUrl { get; set; } 

}
public class UpdateServiceCommand: IRequest
{
    public int Id { get; set; } 
    public string Title { get; set; } 
    public string Description { get; set; } 
    public string IconUrl { get; set; } 
}
public class DeleteServiceCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}