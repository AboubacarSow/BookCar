namespace BookCar.Application.Features.CQRS.Results.Contacts;
public class GetContactQueryResult(int id, string name, string email, string subject, string message, DateTime sendDate)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Email { get; set; }=email;
    public string Subject { get; set; }= subject;
    public string Message { get; set; }=message;
    public DateTime SendDate { get; set; } = sendDate;
}
public class GetContactByIdQueryResult(int id, string name, string email, string subject, string message, DateTime sendDate)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
    public string Subject { get; set; } = subject;
    public string Message { get; set; } = message;
    public DateTime SendDate { get; set; } = sendDate;
}