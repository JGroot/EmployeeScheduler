using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using McWendellKingSchedule.Models;
using McWendellKingSchedule.ViewModels.ScheduleDetails;
using Microsoft.AspNet.Authorization;

namespace McWendellKingSchedule.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private ApplicationDbContext _context;

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;  
              
        }

        // GET: Schedule
        [Authorize]
        public IActionResult Index()
        {
            var applicationDbContext = _context.Schedule.Include(s => s.Employee);
            return View(applicationDbContext.ToList());
        }

        // GET: Schedule/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Schedule schedule = _context.Schedule.Single(m => m.ScheduleID == id);
            if (schedule == null)
            {
                return HttpNotFound();
            }

            return View(schedule);
        }

        // GET: Schedule/Create
        public IActionResult Create()
        {
           // ViewData["UserName"] = new SelectList(_context.Employee, "UserName", "Employee");
            PopulateEmployeeUserNameDropDownList();
            
            return View();
        }

        // POST: Schedule/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Schedule.Add(schedule);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["UserName"] = new SelectList(_context.Employee, "UserName", "Employee", schedule.UserName);
            return View(schedule);
        }

        // GET: Schedule/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Schedule schedule = _context.Schedule.Single(m => m.ScheduleID == id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            PopulateEmployeeUserNameDropDownList(schedule.UserName);
            return View(schedule);
        }

        // POST: Schedule/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Update(schedule);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["UserName"] = new SelectList(_context.Employee, "UserName", "Employee", schedule.UserName);
            return View(schedule);
        }

     
        // GET: Schedule/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Schedule schedule = _context.Schedule.Single(m => m.ScheduleID == id);
            if (schedule == null)
            {
                return HttpNotFound();
            }

            return View(schedule);
        }

        // POST: Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = _context.Schedule.Single(m => m.ScheduleID == id);
            _context.Schedule.Remove(schedule);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateEmployeeUserNameDropDownList(object selectedEmployee = null)
        {
            var employeeQuery = from e in _context.Employee
                                orderby e.UserName
                                select e;
            ViewData["UserName"] = new SelectList(employeeQuery, "UserName", "UserName", selectedEmployee);
        }

        // GET: ~/Views/Shared/Components/ScheduleDetail/Create
        public IActionResult AddDetail(int? id)
        {
            PopulateShiftDropDownList();
            PopulatePositionDropDownList();
            PopulateEmployeeNameDropDownList();
            ViewData["ScheduleID"] = id;
            return View("~/Views/Shared/Components/ScheduleDetail/Create.cshtml");
        }

        // POST: ~/Views/Shared/Components/ScheduleDetail/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDetail(AddNewDetail newDetail)
        {
            ScheduleDetail scheduleDetail = new ScheduleDetail();
            
            string[] fullName = newDetail.FullName.Split(' ');
            scheduleDetail.FirstName = fullName[0];
            scheduleDetail.LastName = fullName[1];
            scheduleDetail.Date = newDetail.Date;
            scheduleDetail.ShiftName = newDetail.ShiftName;
            scheduleDetail.PositionName = newDetail.PositionName;
            scheduleDetail.ScheduleID = newDetail.ScheduleID;

            if (ModelState.IsValid)
            {
                _context.ScheduleDetail.Add(scheduleDetail);
                _context.SaveChanges();
                return RedirectToAction("Edit", new { id = scheduleDetail.ScheduleID });
            }
            return View(scheduleDetail);
        }

        // GET: Schedule/EditDetail/1
        [HttpGet]
        public IActionResult EditDetail(int? id)
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

            PopulateEmployeeNameDropDownList(scheduleDetail.FullName);
            PopulateShiftDropDownList(scheduleDetail.ShiftName);
            PopulatePositionDropDownList(scheduleDetail.PositionName);
            ViewData["ScheduleID"] = scheduleDetail.ScheduleID;
            return View(scheduleDetail);
        }

        // POST: Schedule/EditDetail/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDetail(EditDetail editDetail)
        {
            ScheduleDetail scheduleDetail = new ScheduleDetail();
            if (ModelState.IsValid)
            { 
                string[] fullName = editDetail.FullName.Split(' ');
                scheduleDetail.FirstName = fullName[0];
                scheduleDetail.LastName = fullName[1];
                scheduleDetail.Date = editDetail.Date;
                scheduleDetail.ShiftName = editDetail.ShiftName;
                scheduleDetail.PositionName = editDetail.PositionName;
                scheduleDetail.ScheduleID = editDetail.ScheduleID;
                scheduleDetail.ID = editDetail.ID;
                _context.Update(scheduleDetail);
                _context.SaveChanges();
                return RedirectToAction("Edit", new { id = scheduleDetail.ScheduleID });
            }
            return View(scheduleDetail);
        }

        // GET: Schedule/DeleteDetail/1
        [ActionName("DeleteDetail")]
        public IActionResult DeleteDetail(int? id)
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

        // POST: Schedule/DeleteDetail/1
        [HttpPost, ActionName("DeleteDetail")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDetailConfirmed(int id)
        {
            ScheduleDetail scheduleDetail = _context.ScheduleDetail.Single(m => m.ID == id);
            int scheduleID = scheduleDetail.ScheduleID;
            _context.ScheduleDetail.Remove(scheduleDetail);
            _context.SaveChanges();
            return RedirectToAction("Edit", new { id = scheduleID});
        }


        private void PopulateEmployeeNameDropDownList(object selectedEmployee = null)
        {
            var employeeQuery = from e in _context.Employee
                                orderby e.FullName
                                select e;

            ViewData["FullName"] = new SelectList(employeeQuery, "FullName", "FullName", selectedEmployee);
        }

        private void PopulateShiftDropDownList(object selectedShift = null)
        {
            var shiftsQuery = from s in _context.Shift
                              orderby s.ShiftName
                              select s;
            ViewBag.ShiftName = new SelectList(shiftsQuery, "ShiftName", "ShiftName", selectedShift);
        }

        private void PopulatePositionDropDownList(object selectedPosition = null)
        {
            var positionsQuery = from s in _context.Position
                                 where s.isActive
                                 orderby s.PositionName
                                 select s;
            ViewBag.PositionName = new SelectList(positionsQuery, "PositionName", "PositionName", selectedPosition);
        }

        private void PopulateUserNameDropDownList(object selectedUserName = null)
        {
            var userQuery = from s in _context.Employee
                            where s.isActive
                            orderby s.UserName
                            select s;
            ViewBag.UserNames = new SelectList(userQuery, "UserName", "UserName", selectedUserName);
        }
    }
}
