using MVC.Models;

namespace MVC.Infrastructure.Validators
{
    public interface IStudentValidator
    {
        void ValidateCreateModel(StudentViewModel model);
    }
}