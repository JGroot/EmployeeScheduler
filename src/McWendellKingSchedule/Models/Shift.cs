using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McWendellKingSchedule.Models
{
    public class Shift
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Shift")]
        public string ShiftName { get; set; }

        [Display(Name = "Description")]
        public string ShiftDescription { get; set; }

        [Required]
        [Display(Name = "Start")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime ShiftStart { get; set; }

        [Required]
        [Display(Name = "End")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime ShiftEnd { get; set; }

        [Display(Name = "Active")]
        public bool isActive { get; set; }

        public virtual ICollection<ScheduleDetail> ScheduleDetail { get; set; }
    }
}
