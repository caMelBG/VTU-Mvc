using DataBase.Models;
using MVC.Infrastructure.Mapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class CourseViewModel : IMapFrom<Course>, IMapTo<Course>
    {
        [Display(Name = "Id")]
        public int CourseID { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Credits")]
        public int Credits { get; set; }

        public virtual ICollection<EnrollmentViewModel> Enrollments { get; set; }
    }
}