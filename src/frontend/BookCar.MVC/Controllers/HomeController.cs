using AutoMapper;
using BookCar.MVC.Interfaces;
using BookCar.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookCar.MVC.Controllers;

public class HomeController(ILogger<HomeController> logger,IMapper _mapper) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> About([FromServices]IAboutService aboutService, [FromServices]ITestimonialService testimonialService)
    {
        var model= await aboutService.GetAbout();   
        var modelView=_mapper.Map<AboutViewModel>(model) with
        {
            Testimonials = await testimonialService.GetTestimonials()
        };
        return View(modelView);
    }

    public async Task<IActionResult> Services([FromServices]IHizmetService hizmetService)
    {
        var hizmetler = hizmetService.GetHizmetler().GetAwaiter().GetResult();
        return View(hizmetler);
    }
    
    public IActionResult Pricing()
    {
        return View();
    }
    public IActionResult Cars()
    {
        return View();
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SendContact(ContactDto model, [FromServices] IContactService contactService)
    {
        if (ModelState.IsValid)
        {
            var result=await contactService.SendContactMessage(model);
            return Json( new {success=result,});
        }
        ModelState.AddModelError("", "Invalid data provided");
        return RedirectToAction(nameof(Contact), model);
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
