using BookCar.Application.Features.CQRS.Commands.Abouts;
using BookCar.Application.Features.CQRS.Handlers.Abouts;
using BookCar.Application.Features.CQRS.Queries;
using BookCar.Application.Features.CQRS.Queries.Abouts;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.Presentation.Controllers;

[ApiController]
[Route("api/abouts")]
public class AboutsController : ControllerBase
{
    private readonly GetAboutQueryHandler _handler;
    private readonly GetAboutByIdQueryHandler _getByIdHandler;
    private readonly CreateAboutCommandHandler _createCommandHandler;
    private readonly UpdateAboutCommandHandler _updateCommandHandler;
    private readonly RemoveAboutCommandHandler _removeCommandHandler;
    public AboutsController(GetAboutQueryHandler handler, GetAboutByIdQueryHandler getByIdHandler,
        CreateAboutCommandHandler createCommandHandler, 
        UpdateAboutCommandHandler updateCommandHandler, RemoveAboutCommandHandler removeCommandHandler)
    {
        _handler = handler;
        _getByIdHandler = getByIdHandler;
        _createCommandHandler = createCommandHandler;
        _updateCommandHandler = updateCommandHandler;
        _removeCommandHandler = removeCommandHandler;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var abouts = await _handler.Handle();
        return Ok(abouts);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOneById([FromRoute]int id)
    {
        var about=await _getByIdHandler.Handle( new GetAboutByIdQuery(id));
        return Ok(about);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOneAbout(CreateAboutCommand model)
    {
        await _createCommandHandler.Handle(model );
        return Ok(new { StatusCode = 201, message = $"Başlık :{model.Title} olan Hakkında öğesi başarıyla oluşturuldu" });
    }
    [HttpPut]
    public async Task<IActionResult> UpdateOneAbout(UpdateAboutCommand model)
    {
        await _updateCommandHandler.Handle(model );
        return Ok(new { StatusCode = 200, message = $"Id'si :{model.Id} olan Hakkında öğesi başarıyla güncellendi", About = model });

    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _removeCommandHandler.Handle(new RemoveAboutCommand(id));
        return Ok(new { StatusCode = 200, message = $"Id'si :{id} olan Hakkında öğesi başarıyla silindi" });
    }
}
