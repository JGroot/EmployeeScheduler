using McWendellKingSchedule.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Controllers;
using System;
using System.Linq;


namespace McWendellKingSchedule.ViewComponents
{
    public class ScheduleDetailViewComponent : ViewComponent
    {
        private ApplicationDbContext _context;

        public ScheduleDetailViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var details = (from sd in _context.ScheduleDetail.ToList()
                           where sd.ScheduleID == id
                           select sd).ToList();

            ViewData["ScheduleID"] = id;
            return View(details);
        }

        private IViewComponentResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // GET: ScheduleDetail/Create
        public IViewComponentResult Create()
        {
            return View();
        }

        
    }
}
