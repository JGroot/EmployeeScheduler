using System;
using System.Collections.Generic;
using McWendellKingSchedule.Models;
using System.ComponentModel.DataAnnotations;

namespace McWendellKingSchedule.ViewModels.ScheduleDetails
{
    public class ScheduleList
    {       
        public int ScheduleID { get; set; }
        public IEnumerable<ScheduleDetail> ScheduleDetail { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Position")]
        public string PositionName { get; set; }

        [Display(Name = "Shift")]
        public string ShiftName { get; set; }
    }
}
