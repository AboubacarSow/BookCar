

using BookCar.Application.Features.CQRS.Commands.Categories;
using BookCar.Application.Features.CQRS.Handlers.Categories;
using BookCar.Application.Features.CQRS.Queries.Categories;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BookCar.Presentation.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController: ControllerBase
{
    private readonly GetCategoryByIdQueryHandler _getByIdHandler;
    private readonly GetCategoryQueryHandler _getHandler;
    private readonly CreateCategoryCommandHandler _createHandler;
    private readonly UpdateCategoryCommandHandler _updateHandler;
    private readonly RemoveCategoryCommandHandler _removeHandler;
    public CategoriesController(GetCategoryQueryHandler getHandler, GetCategoryByIdQueryHandler getByIdHandler,
        CreateCategoryCommandHandler createHandler, UpdateCategoryCommandHandler updateHandler,
        RemoveCategoryCommandHandler removeHanlder)
    {
        _getByIdHandler = getByIdHandler;
        _createHandler = createHandler;
        _getHandler=getHandler;
        _updateHandler=updateHandler;
        _removeHandler=removeHanlder;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _getHandler.Handle();
        return Ok(categories);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _getByIdHandler.Handle(new GetCategoryByIdQuery(id));
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand request)
    {
        await _createHandler.Handle(request);
        return Ok(new { StatusCode = 201, Message = $"Category with Name:{request.Name} has been successfully created" });
    }
    [HttpPut]
    public async Task<IActionResult> Edit(UpdateCategoryCommand request)
    {
        await _updateHandler.Handle(request);
        return Ok(new { StatusCode = 200, Message = $"Category with Id:{request.Id} has been successfully updated" ,Category=request});
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery]int id)
    {
        await _removeHandler.Handle(new RemoveCategoryCommand(id));
        return Ok(new { StatusCode = 200, Message = $"Category with Id :{id} has been successfully deleted" });
    }
}
