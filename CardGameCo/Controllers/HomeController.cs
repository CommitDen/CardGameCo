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
        User sessionUser = _db.AspNetUsers.Single(x => x.Email == user.Email);

        if (sessionUser is null)
            throw new Exception("Wrong Email!");

        if (sessionUser.PasswordHash != user.PasswordHash)
            throw new Exception("Wrong Password!");

        HttpContext.Session.SetString("Email", sessionUser.Email);
        HttpContext.Session.SetString("UserName", sessionUser.UserName);

        return View("Main");
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        User user = new User();

        return View(user);
    }

    [HttpPost]
    public IActionResult SignUp(User user)
    {
        if (!ModelState.IsValid)
        {
            // Model validation failed, return the view with error messages
            return View(user);
        }

        if (_db.AspNetUsers.Select(x=>x.Email == user.Email) != null)
        {
            // Add a specific validation error message for a property
            ModelState.AddModelError("Email", "There is already an account associated with this email adress!");

            // Return the view with validation errors
            return View(user);
        }

        _db.AspNetUsers.Add(user);
        _db.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}