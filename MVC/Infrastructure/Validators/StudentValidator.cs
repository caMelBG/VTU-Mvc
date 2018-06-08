using System;
using MVC.Models;

namespace MVC.Infrastructure.Validators
{
    public class StudentValidator : IStudentValidator
    {
        public void ValidateCreateModel(StudentViewModel model)
        {
            if (string.IsNullOrEmpty(model.FirstMidName))
            {
                throw new Exception($"Student first name is required.");
            }
            else if (model.FirstMidName.Length < 5 && model.FirstMidName.Length > 25)
            {
                throw new Exception($"Student first name must be between 5 and 25 characters.");
            }
            else if (string.IsNullOrEmpty(model.LastName))
            {
                throw new Exception($"Student last name is required.");
            }
            else if (model.FirstMidName.Length < 5 && model.FirstMidName.Length > 25)
            {
                throw new Exception($"Student last name must be between 5 and 25 characters.");
            }
            else if (model.EnrollmentDate == null)
            {
                throw new Exception($"Student enrollment date is required.");
            }
        }
    }
}