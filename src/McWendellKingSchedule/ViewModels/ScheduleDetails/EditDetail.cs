using System;
using McWendellKingSchedule.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McWendellKingSchedule.ViewModels.ScheduleDetails
{
    public class EditDetail
    {
        public int ID { get; set; }
        public int ScheduleID { get; set; }

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
