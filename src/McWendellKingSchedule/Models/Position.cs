using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McWendellKingSchedule.Models
{
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Position")]
        public string PositionName { get; set; }

        [Display(Name = "Description")]
        public string PositionDescription { get; set; }

        [Display(Name = "Active")]
        public bool isActive { get; set; }

        public virtual ICollection<ScheduleDetail> ScheduleDetail { get; set; }
    }
}
