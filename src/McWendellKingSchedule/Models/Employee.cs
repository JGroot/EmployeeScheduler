using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McWendellKingSchedule.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "UserName")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string _fullName;
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
            set { _fullName = value; }
        }

        [Required]
        [Display(Name = "Active")]
        public bool isActive { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
        public virtual ICollection<ScheduleDetail> ScheduleDetail { get; set; }
    }
}
