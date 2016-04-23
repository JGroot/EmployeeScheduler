using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using McWendellKingSchedule.Models;
using Microsoft.AspNet.Authorization;

namespace McWendellKingSchedule.Controllers
{   
    [Authorize]
    public class PositionController : Controller
    {
        private ApplicationDbContext _context;

        public PositionController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Position
        public IActionResult Index()
        {
            return View(_context.Position.ToList());
        }

        // GET: Position/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Position position = _context.Position.Single(m => m.PositionName == id);
            if (position == null)
            {
                return HttpNotFound();
            }

            return View(position);
        }

        // GET: Position/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Position/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Position position)
        {
            if (ModelState.IsValid)
            {
                _context.Position.Add(position);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        // GET: Position/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Position position = _context.Position.Single(m => m.PositionName == id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Position/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Position position)
        {
            if (ModelState.IsValid)
            {
                _context.Update(position);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        // GET: Position/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Position position = _context.Position.Single(m => m.PositionName == id);
            if (position == null)
            {
                return HttpNotFound();
            }

            return View(position);
        }

        // POST: Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            Position position = _context.Position.Single(m => m.PositionName == id);
            _context.Position.Remove(position);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
