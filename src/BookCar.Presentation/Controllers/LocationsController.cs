namespace BookCar.Presentation.Controllers;

[ApiController]
[Route("api/locatins")]
public class LocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetLocationQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetLocationByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateLocationCommand command)
    {
        await _mediator.Send(command);
        return Ok(new {Message="Lokasyon başarıyla eklendi"});
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new RemoveLocationCommand(id));
        return Ok(new {Message="Lokasyon başarıyla silindi"});
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdateLocationCommand command)
    {
        await _mediator.Send(command);
        return Ok( new {Message="Lokasyon başarıyla güncellendi"});
    }
}
[ApiController]
[Route("api/pricings")]
public class PricingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PricingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetPricingQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetPricingByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePricingCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Message = "Ödeme Türü başarıyla eklendi" });
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new RemovePricingCommand(id));
        return Ok(new { Message = "Ödeme Türü başarıyla silindi" });
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdatePricingCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Message = "Ödeme Türü başarıyla güncellendi" });
    }
}

[ApiController]
[Route("api/services")]
public class ServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetServiceQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetServiceByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Message = "Hizmet başarıyla eklendi" });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new RemoveServiceCommand(id));
        return Ok(new { Message = "Hizmet başarıyla silindi" });
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateServiceCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Message = "Hizmet başarıyla güncellendi" });
    }

}
[ApiController]
[Route("api/socialmedias")]
public class SocialMediasController : ControllerBase
{
    private readonly IMediator _mediator;

    public SocialMediasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetSocialMediaQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetSocialMediaByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSocialMediaCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Message = "Sosyal Medya başarıyla eklendi" });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new RemoveSocialMediaCommand(id));
        return Ok(new { Message = "Sosyal Medya başarıyla silindi" });
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateSocialMediaCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Message = "Sosyal Medya başarıyla güncellendi" });
    }
}
