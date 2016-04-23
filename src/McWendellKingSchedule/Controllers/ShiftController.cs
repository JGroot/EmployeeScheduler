using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using McWendellKingSchedule.Models;
using Microsoft.AspNet.Authorization;

namespace McWendellKingSchedule.Controllers
{
    [Authorize]
    public class ShiftController : Controller
    {
        private ApplicationDbContext _context;

        public ShiftController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Shift
        public IActionResult Index()
        {
            return View(_context.Shift.ToList());
        }

        // GET: Shift/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Shift shift = _context.Shift.Single(m => m.ShiftName == id);
            if (shift == null)
            {
                return HttpNotFound();
            }

            return View(shift);
        }

        // GET: Shift/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shift/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Shift shift)
        {
            if (ModelState.IsValid)
            {
                _context.Shift.Add(shift);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shift);
        }

        // GET: Shift/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Shift shift = _context.Shift.Single(m => m.ShiftName == id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return View(shift);
        }

        // POST: Shift/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Shift shift)
        {
            if (ModelState.IsValid)
            {
                _context.Update(shift);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shift);
        }

        // GET: Shift/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Shift shift = _context.Shift.Single(m => m.ShiftName == id);
            if (shift == null)
            {
                return HttpNotFound();
            }

            return View(shift);
        }

        // POST: Shift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            Shift shift = _context.Shift.Single(m => m.ShiftName == id);
            _context.Shift.Remove(shift);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
