using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McWendellKingSchedule.Models
{
    public class ScheduleDetail
    {

        public int ID { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScheduleID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string _fullName;

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
            set { _fullName = value; }
        }

        [Required]
        [Display(Name = "Shift")]
        public string ShiftName { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string PositionName { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual Position Position { get; set; }
    }
}
