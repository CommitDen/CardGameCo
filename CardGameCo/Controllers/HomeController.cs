using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CardGameCo.Models;
using CardGameCo.Interfaces;

namespace CardGameCo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(new TimeSpan(0, 0, 10));
    }

    public IActionResult Privacy()
    {

        List<ICard> cards = //Cards list with other type of classes implementing the same interface
        for (int i = 0; i < 2; i++)
        {
            cards[i].German = "h";
        }
        return RedirectToAction("Index",nameof(HomeController));
    }


    [HttpGet]
    public IActionResult Edit(/*int Id*/)
    {
        //get data from database fill model and return it to view
        return View(/*model*/);

    }

    [HttpPost]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(/*stealth model*/)
    {
        // Check how this shit works
        //dbcontext.Save(model);
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

// asd https://localhost:7016/Home/Privacy