using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CardGameCo.Models;
using CardGameCo.Interfaces;
using CardGameCo.Data;
using Microsoft.AspNetCore.Http;

namespace CardGameCo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(User user)
    {
        User sessionUser = _db.Users.Single(x => x.Email == user.Email);

        if (sessionUser is null)
            throw new Exception("Wrong Email!");

        if (sessionUser.Password != user.Password)
            throw new Exception("Wrong Password!");

        HttpContext.Session.SetString("Email", sessionUser.Email);
        HttpContext.Session.SetString("UserName", sessionUser.Name);

        return View("Main");
    }

    [HttpPost]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}