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
        [Required(ErrorMessage = "Student first name is required.")]
        [StringLength(maximumLength: 25, ErrorMessage = "Student first name must be between 5 and 25 characters.", MinimumLength = 5)]
        public string LastName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Student last name is required.")]
        [StringLength(maximumLength: 25, ErrorMessage = "Student last name must be between 5 and 25 characters.", MinimumLength = 5)]
        public string FirstMidName { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Student enrollment date is required.")]
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<EnrollmentViewModel> Enrollments { get; set; }
    }
}