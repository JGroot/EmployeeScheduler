using System.Collections.Generic;
using McWendellKingSchedule.Models;
using System.ComponentModel.DataAnnotations;


using System;
using McWendellKingSchedule.Migrations;

namespace McWendellKingSchedule.ViewModels.ScheduleDetails
{
    public class CalendarView
    {
        [Key]
        public int ScheduleID { get; set; }
        public IEnumerable<ScheduleDetail> ScheduleDetails { get; set; }

        public IEnumerable<string> Positions { get; set; }
        public IEnumerable<string> Shifts { get; set; }
        public IEnumerable<DateTime> DetailDate { get; set; }
    }
}
