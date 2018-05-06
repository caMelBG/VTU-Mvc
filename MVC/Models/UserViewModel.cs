using DataBase.Models;
using MVC.Infrastructure.Mapping;

namespace MVC.Models
{
    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }
        
        public string UserName { get; set; }

        public bool IsAdmin { get; set; }
    }
}