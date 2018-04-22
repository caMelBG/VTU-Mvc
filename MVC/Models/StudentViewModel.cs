using DataBase.Models;
using MVC.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class StudentViewModel : IMapFrom<Student>, IMapTo<Student>
    {
        [Display(Name = "Id")]
        public int StudentID { get; set; }

        [Display(Name = "First name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Last name")]
        [Required]
        public string FirstMidName { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<EnrollmentViewModel> Enrollments { get; set; }
    }
}