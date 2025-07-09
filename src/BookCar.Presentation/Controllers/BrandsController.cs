using BookCar.Application.Features.CQRS.Commands.Banners;
using BookCar.Application.Features.CQRS.Commands.Brands;
using BookCar.Application.Features.CQRS.Handlers.Brands;
using BookCar.Application.Features.CQRS.Queries.Brands;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.Presentation.Controllers;

[ApiController]
[Route("api/brands")]
public class BrandsController:ControllerBase
{
    private GetBrandQueryHandler _getBrandQueryHandler;
    private readonly GetBrandByIdQueryHandler _getByIdHandler;
    private readonly CreateBrandCommandHandler _createHandler;
    private readonly UpdateBrandCommandHandler _updateHandler;
    private readonly DeleteBrandCommandHandler _deleteHanlder;

    public BrandsController(GetBrandQueryHandler getBrandQueryHandler, GetBrandByIdQueryHandler getByIdHandler,
        CreateBrandCommandHandler createHandler, UpdateBrandCommandHandler updateHandler, DeleteBrandCommandHandler deleteHanlder)
    {
        _getBrandQueryHandler= getBrandQueryHandler;
        _getByIdHandler = getByIdHandler;
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHanlder = deleteHanlder;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var brands = await _getBrandQueryHandler.Handle();
        return Ok(brands);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        var brand = await _getByIdHandler.Handle(new GetBrandByIdQuery(id));
        return Ok(brand);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBrandCommand command)
    {
        await _createHandler.Handle(command);
        return Ok(new { StatusCode = 201, message = $"Brand with Name:{command.Name} has been successfully created" });
    }

    [HttpPut]
    public async Task<IActionResult> Edit(UpdateBrandCommand command)
    {
        await _updateHandler.Handle(command);
        return Ok(new { StatusCode = 200, message = $"Id'si olan: {command.Id} Brand öğesi başarıyla güncellendi", Banner = command });

    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete( int id)
    {
        await _deleteHanlder.Handle(new DeleteBrandCommand(id));
        return Ok(new { StatusCode = 200, message = $"Id'si :{id} olan Brand öğesi başarıyla silindi" });
    }
}
