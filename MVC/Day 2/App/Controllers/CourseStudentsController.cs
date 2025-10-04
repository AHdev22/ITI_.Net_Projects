using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Models;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class CourseStudentsController : BaseController<CourseStudents>
    {
        private readonly ILogger<DepartmentsController> _logger;

        public CourseStudentsController(UniversityContext context, ILogger<DepartmentsController> logger)
            : base(context)
        {
            _logger = logger;
        }
        // Index is specific to Departments
        public IActionResult Index()
        {
            var list = _context.Set<CourseStudents>().ToList(); // use inherited _context
            return View(list);
        }
    }
}
