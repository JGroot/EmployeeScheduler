using System;
using System.Linq;
using McWendellKingSchedule.Models;
using Microsoft.AspNet.Mvc;

namespace McWendellKingSchedule.ViewComponents
{
    public class CalendarView : ViewComponent
    {
        private ApplicationDbContext _context;

        public CalendarView(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var details = (from sd in _context.ScheduleDetail.ToList()
                           where sd.ScheduleID == id
                           orderby sd.Date, sd.Shift, sd.Position, sd.FullName
                           select sd).ToList();

            ViewModels.ScheduleDetails.CalendarView calendar = new ViewModels.ScheduleDetails.CalendarView();
            calendar.ScheduleID = (int)id;
            calendar.ScheduleDetails = details;
            calendar.DetailDate = details.OrderBy(d => d.Date).Select(d => d.Date);
            calendar.DetailDate = calendar.DetailDate.GroupBy(d => d.Date).Select(group => group.First());
            calendar.Shifts = _context.Shift.OrderBy(s => s.ShiftStart).Select(s => s.ShiftName);
            calendar.Positions = _context.Position.OrderBy(p => p.PositionName).Select(p => p.PositionName);
           
            return View(calendar);
        }

        private IViewComponentResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}
