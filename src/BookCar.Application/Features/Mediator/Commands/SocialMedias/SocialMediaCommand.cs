namespace BookCar.Application.Features.Mediator.Commands.SocialMedias;

public class CreateSocialMediaCommand: IRequest
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; } 
        
}
public class UpdateSocialMediaCommand : IRequest
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string Url { get; set; } 
    public string Icon { get; set; } 
}
public class DeleteSocialMediaCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}
