using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using McWendellKingSchedule.Models;

namespace McWendellKingSchedule.ViewModels
{
    public class EditSchedule
    {
        public int ScheduleID { get; set; }

        public string SelectedUserName { get; set; }
        public IEnumerable<Employee> UserNames{ get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateEnd { get; set; }
    }
}
