using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Models;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class StudentsController : BaseController<Student>
    {
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(UniversityContext context, ILogger<StudentsController> logger) : base(context)
        {
            _logger = logger;
        }
        // Index is specific to Departments
        public IActionResult Index()
        {
            var list = _context.Set<Student>().ToList(); // use inherited _context
            return View(list);
        }
    }
}
