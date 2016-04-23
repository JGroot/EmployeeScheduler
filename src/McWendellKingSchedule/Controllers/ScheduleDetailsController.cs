using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using McWendellKingSchedule.Models;
using McWendellKingSchedule.ViewModels.ScheduleDetails;

namespace McWendellKingSchedule.Controllers
{
    public class ScheduleDetailsController : Controller
    {
        private ApplicationDbContext _context;

        public ScheduleDetailsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ScheduleDetails
        public IActionResult Index()
        {
            var applicationDbContext = _context.ScheduleDetail.Include(s => s.Position).Include(s => s.Shift).Include(s => s.ScheduleID).Include(s => s.FirstName).Include(s => s.LastName);
            return View(applicationDbContext.ToList());
        }

        // GET: ScheduleDetails/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ScheduleDetail scheduleDetail = _context.ScheduleDetail.Single(m => m.ID == id);
            if (scheduleDetail == null)
            {
                return HttpNotFound();
            }

            return View(scheduleDetail);
        }

        // GET: ScheduleDetails/Create
        public IActionResult Create()
        {
            ViewData["PositionName"] = new SelectList(_context.Position, "PositionName", "Position");
            ViewData["ScheduleID"] = new SelectList(_context.Schedule, "ScheduleID", "Schedule");
            ViewData["ShiftName"] = new SelectList(_context.Shift, "ShiftName", "Shift");
            return View();
        }

        // POST: ScheduleDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ScheduleDetail scheduleDetail)
        {
            if (ModelState.IsValid)
            {
                _context.ScheduleDetail.Add(scheduleDetail);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["PositionName"] = new SelectList(_context.Position, "PositionName", "Position", scheduleDetail.PositionName);
            ViewData["ScheduleID"] = new SelectList(_context.Schedule, "ScheduleID", "Schedule", scheduleDetail.ScheduleID);
            ViewData["ShiftName"] = new SelectList(_context.Shift, "ShiftName", "Shift", scheduleDetail.ShiftName);
            return View(scheduleDetail);
        }

        // GET: ScheduleDetails/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ScheduleDetail scheduleDetail = _context.ScheduleDetail.Single(m => m.ID == id);
            if (scheduleDetail == null)
            {
                return HttpNotFound();
            }
            ViewData["PositionName"] = new SelectList(_context.Position, "PositionName", "Position", scheduleDetail.PositionName);
            ViewData["ScheduleID"] = new SelectList(_context.Schedule, "ScheduleID", "Schedule", scheduleDetail.ScheduleID);
            ViewData["ShiftName"] = new SelectList(_context.Shift, "ShiftName", "Shift", scheduleDetail.ShiftName);
            return View(scheduleDetail);
        }

        // POST: ScheduleDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ScheduleDetail scheduleDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Update(scheduleDetail);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["PositionName"] = new SelectList(_context.Position, "PositionName", "Position", scheduleDetail.PositionName);
            ViewData["ScheduleID"] = new SelectList(_context.Schedule, "ScheduleID", "Schedule", scheduleDetail.ScheduleID);
            ViewData["ShiftName"] = new SelectList(_context.Shift, "ShiftName", "Shift", scheduleDetail.ShiftName);
            return View(scheduleDetail);
        }

        // GET: ScheduleDetails/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ScheduleDetail scheduleDetail = _context.ScheduleDetail.Single(m => m.ID == id);
            if (scheduleDetail == null)
            {
                return HttpNotFound();
            }

            return View(scheduleDetail);
        }

        // POST: ScheduleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ScheduleDetail scheduleDetail = _context.ScheduleDetail.Single(m => m.ID == id);
            _context.ScheduleDetail.Remove(scheduleDetail);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
