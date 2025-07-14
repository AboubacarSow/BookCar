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
    public async Task<IActionResult> About([FromServices]IAboutService aboutService)
    {
        var model= await aboutService.GetAbout();   
        var modelView=_mapper.Map<AboutViewModel>(model);
        return View(modelView);
    }

    public IActionResult Services()
    {
        return View();
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
    public IActionResult Contact()
    {
        return View();
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
