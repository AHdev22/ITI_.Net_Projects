using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Models;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class DepartmentsController : BaseController<Department>
    {
        private readonly ILogger<DepartmentsController> _logger;

        public DepartmentsController(UniversityContext context, ILogger<DepartmentsController> logger) : base(context)
        {
            _logger = logger;
        }


        // Index is specific to Departments
        public IActionResult Index()
        {
            var list = _context.Set<Department>().ToList(); // use inherited _context
            return View(list);
        }

    }
}

