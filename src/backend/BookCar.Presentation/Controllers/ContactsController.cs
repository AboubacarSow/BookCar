using BookCar.Application.Features.CQRS.Commands.Contacts;
using BookCar.Application.Features.CQRS.Handlers.Contacts;
using BookCar.Application.Features.CQRS.Queries.Contacts;
using BookCar.Application.Features.Mediator.Commands.ContactInfos;
using BookCar.Application.Features.Mediator.Queries.ContactInfos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookCar.Presentation.Controllers;


[ApiController]
[Route("api/contacts")]
public class ContactsController: ControllerBase
{
    private readonly GetContactQueryHandler _getHandler;
    private readonly GetContactByIdQueryHandler _getByIdHandler;
    private readonly CreateContactCommandHandler _createHandler;
    private readonly UpdateContactCommandHandler _updateHandler;
    private readonly DeleteContactCommandHandler _deleteHandler;
    public ContactsController(GetContactQueryHandler getHandler, GetContactByIdQueryHandler getByIdHandler, 
        CreateContactCommandHandler createHandler, UpdateContactCommandHandler updateHandler, 
        DeleteContactCommandHandler deleteHandler)
    {
        _getHandler = getHandler;
        _getByIdHandler = getByIdHandler;
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contacts = await _getHandler.Handle();
        return Ok(contacts);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var contact = await _getByIdHandler.Handle(new GetContactByIdQuery(id));
        return Ok(contact);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateContactCommand request)
    {
        await _createHandler.Handle(request);
        return Ok( new {StatusCode = 201, Message=$"Contact with Name: {request.Name} has been successfully created"});
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateContactCommand request)
    {
        await _updateHandler.Handle(request);
        return Ok(new { StatusCode = 200, Message = $"Contact with Id:{request.Id} has been successfully updated" });
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _deleteHandler.Handle(new DeleteContactCommand(id));
        return Ok(new { StatusCode = 200, Message = $"Contact with Id: {id} has been successfully deleted"});

    }

}

[ApiController]
[Route("api/contactInfos")]
public class ContactInfosController(ISender sender):ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dtos = await sender.Send(new GetContactInfosQuery());
        return Ok(dtos);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOneContactInfo(CreateContactInfoCommand command)
    {
        var result=await sender.Send(command);

        return Ok($"Contact Info with Id:{result} has been successfully created");
       
    }


}
