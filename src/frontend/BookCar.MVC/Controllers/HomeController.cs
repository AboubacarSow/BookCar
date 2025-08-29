using AutoMapper;
using BookCar.MVC.Interfaces;
using BookCar.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BookCar.MVC.Controllers;

public class HomeController(ILogger<HomeController> logger,IMapper _mapper,IContactService contactService) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public async Task<IActionResult> Index([FromServices]IHizmetService service, 
        [FromServices]ITestimonialService testimonialService,
        [FromServices]IAboutService aboutService)
    {
        var viewModel= new IndexViewModel 
        { 
            AboutInfo= _mapper.Map<AboutInfo>(await aboutService.GetAbout()),
            Hizmetler=await  service.GetHizmetler(),
            Testimonials=await testimonialService.GetTestimonials(),

        };
        return View(viewModel);
    }
    public async Task<IActionResult> About([FromServices]IAboutService aboutService, [FromServices]ITestimonialService testimonialService)
    {
        var model= await aboutService.GetAbout();   
       var aboutInfo=_mapper.Map<AboutInfo>(model);
       var aboutViewModel= new AboutViewModel
       {
            AboutInfo=aboutInfo,
            Testimonials=await testimonialService.GetTestimonials()
        };
       
        return View(aboutViewModel);
    }

    public async Task<IActionResult> Services([FromServices]IHizmetService hizmetService)
    {
        var hizmetler =await  hizmetService.GetHizmetler();
        return View(hizmetler);
    }
    
    public IActionResult Pricing()
    {
        return View();
    }
    public async Task<IActionResult> Cars([FromServices] ICarService carService)
    {
        var cars =await carService.GetCarsWithBrand();
        return View(cars);
    }
   

    public IActionResult Blog()
    {
        return View();  
    }
    public async Task<IActionResult> Contact([FromServices] IContactInfoService contactInfoService)
    {
        var data = await contactInfoService.GetContactInfo();
        return View(data);
    }
    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody]ContactDto model)
    {
        try
        {
            var result = await contactService.SendContactMessage(model);
            return Json(new { success = result });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message});

        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
