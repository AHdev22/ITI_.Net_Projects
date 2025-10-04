using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Models;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class CoursesController : BaseController<Course>
    {
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(UniversityContext context, ILogger<CoursesController> logger)
            : base(context)
        {
            _logger = logger;
        }
        // Index is specific to Departments
        public IActionResult Index()
        {
            var list = _context.Set<Course>().ToList(); // use inherited _context
            return View(list);
        }
    }
}
