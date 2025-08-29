using BookCar.Application.Features.CQRS.Commands.Abouts;
using BookCar.Application.Features.CQRS.Commands.Cars;
using BookCar.Application.Features.CQRS.Handlers.Cars;
using BookCar.Application.Features.CQRS.Queries.Cars;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookCar.Presentation.Controllers;


[ApiController]
[Route("api/cars")]
public class CarsController:ControllerBase
{
    private readonly GetCarQueryHandler _getCarQueryHandler;
    private readonly GetCarByIdQueryHandler _getByIdHandler;
    private readonly GetCarWithBrandQueryHandler _getWithBrandQueryHandler;
    private readonly CreateCarCommandHandler _createHandler;
    private readonly UpdateCarCommandHandler _updateHandler;
    private readonly RemoveCarCommandHandler _removeHandler;

    public CarsController(GetCarQueryHandler getCarQueryHandler, GetCarByIdQueryHandler getByIdHandler, GetCarWithBrandQueryHandler getWithBrandQueryHandler, CreateCarCommandHandler createHandler, UpdateCarCommandHandler updateHandler, RemoveCarCommandHandler removeHandler)
    {
        _getCarQueryHandler = getCarQueryHandler;
        _getByIdHandler = getByIdHandler;
        _getWithBrandQueryHandler = getWithBrandQueryHandler;
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _removeHandler = removeHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cars = await _getCarQueryHandler.Handle();
        return Ok(cars);
    }

    [HttpGet("withbrand")]
    public async Task<IActionResult> GetAllWithBrand()
    {
        var cars=await _getWithBrandQueryHandler.Handle();
        return Ok(cars);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
       var car=await _getByIdHandler.Handle(new GetCarByIdQuery(id));
        return Ok(car);
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdateCarCommand request)
    {
        await _updateHandler.Handle(request);
        return Ok(new { StatusCode = 200, Message = $"Car with Id:{request.Id} has been successfully updated", Car = request });
    }
    [HttpPost]
    public  async Task<IActionResult> CreateAsync(CreateCarCommand request)
    {
        await _createHandler.Handle(request);
        return Ok(new { StatusCode = 201, Message = $"Car item with Model:{request.Model} has been successfully create", Car = request });
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _removeHandler.Handle(new RemoveCarCommand(id));
        return Ok(new { StatusCode = 200, Message = $"Car with Id:{id} has been successfully deleted" });
    }
}
