using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class BaseController<T> : Controller where T : class
    {
        protected readonly DbContext _context;

        public BaseController(DbContext context)
        {
            _context = context;
        }

        // GET: Add
        [HttpGet]
        public virtual IActionResult Add()
        {
            var model = Activator.CreateInstance<T>(); // T is Course in CoursesController
            return View("~/Views/Shared/Add.cshtml", model);
        }

        // POST: Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Add(T entity)
        {
            if (ModelState.IsValid)
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Shared/Add.cshtml", entity);
        }

        // GET: Edit
        [HttpGet]
        public virtual IActionResult Edit(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null) return NotFound();
            return View("~/Views/Shared/Edit.cshtml", entity);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Edit(T entity)
        {
            if (ModelState.IsValid)
            {
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Shared/Edit.cshtml", entity);
        }

        // GET: Delete
        [HttpGet]
        public virtual IActionResult Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null) return NotFound();
            return View("~/Views/Shared/Delete.cshtml", entity);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual IActionResult DeleteConfirmed(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null) return NotFound();

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: Details
        [HttpGet]
        public virtual IActionResult Details(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null) return NotFound();

            return View("~/Views/Shared/Details.cshtml", entity);
        }
    }
}
