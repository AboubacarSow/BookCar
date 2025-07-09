using BookCar.Application.Features.CQRS.Commands.Banners;
using BookCar.Application.Features.CQRS.Handlers.Banners;
using BookCar.Application.Features.CQRS.Queries.Banners;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.Presentation.Controllers;
[ApiController]
[Route("api/banners")]
public class BannersController: ControllerBase
{
    private readonly GetBannerQueryHandler _queryHandler;
    private readonly GetBannerByIdQueryHandler _getBannerHandler;
    private readonly CreateBannerCommandHandler _createBannerCommandHandler;
    private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
    private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

    public BannersController(GetBannerQueryHandler getBannerHandler,GetBannerByIdQueryHandler getBannerByIdHandler
        ,CreateBannerCommandHandler createBannerCommandHandler,UpdateBannerCommandHandler updateBannerCommandHandler
        ,RemoveBannerCommandHandler removeBannerCommandHandler)
    {
        _queryHandler = getBannerHandler;
        _getBannerHandler = getBannerByIdHandler;
        _createBannerCommandHandler = createBannerCommandHandler;
        _updateBannerCommandHandler = updateBannerCommandHandler;
        _removeBannerCommandHandler = removeBannerCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var banners = await _queryHandler.Handle();
        return Ok(banners);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromQuery]int id)
    {
       var banner=await _getBannerHandler.Handle(new GetBannerByIdQuery(id));
        return Ok(banner);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBannerCommand command)
    {
        await _createBannerCommandHandler.Handle(command);
        return Ok(new { StatusCode = 201, message = $"Banner with Title:{command.Title} has been successfully created" });
    }

    [HttpPut]
    public async Task<IActionResult> Edit(UpdateBannerCommand command)
    {
        await _updateBannerCommandHandler.Handle(command);
        return Ok(new { StatusCode = 200, message = $"Id'si olan: {command.Id} Banner öğesi başarıyla güncellendi", Banner = command });

    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
        return Ok(new { StatusCode = 200, message = $"Id'si :{id} olan Banner öğesi başarıyla silindi" });
    }
}
