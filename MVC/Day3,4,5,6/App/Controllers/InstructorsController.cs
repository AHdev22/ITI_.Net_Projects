using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Models;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class InstructorsController : BaseController<Instructor>
    {
        private readonly ILogger<InstructorsController> _logger;

        public InstructorsController(UniversityContext context, ILogger<InstructorsController> logger)
            : base(context)
        {
            _logger = logger;
        }
        // Index is specific to Departments
        public IActionResult Index()
        {
            var list = _context.Set<Instructor>().ToList(); // use inherited _context
            return View(list);
        }
    }
}
