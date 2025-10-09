using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using UniversitySystem.Models;
using System.Linq;

namespace App.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UniversityContext _context;

    public HomeController(ILogger<HomeController> logger, UniversityContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var model = new HomeIndexViewModel
        {
            CoursesCount = _context.Courses.Count(),
            StudentsCount = _context.Students.Count(),
            DepartmentsCount = _context.Departments.Count()
        };
        return View(model);
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
