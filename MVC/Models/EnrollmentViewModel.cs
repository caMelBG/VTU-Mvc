using AutoMapper;
using DataBase.Models;
using MVC.Infrastructure.Mapping;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class EnrollmentViewModel : IMapFrom<Enrollment>, IMapTo<Enrollment>
    {
        [Display(Name = "Id")]
        public int EnrollmentID { get; set; }

        [Display(Name = "Course Id")]
        [Required]
        public int CourseID { get; set; }

        [Display(Name = "Student Id")]
        [Required]
        public int StudentID { get; set; }

        [Display(Name = "Grade")]
        public Grade? Grade { get; set; }

        public CourseViewModel Course { get; set; }

        public StudentViewModel Student { get; set; }
    }
}