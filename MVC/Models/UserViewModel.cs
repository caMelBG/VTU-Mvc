using DataBase.Models;
using MVC.Infrastructure.Mapping;
using System.Collections.Generic;

namespace MVC.Models
{
    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }
        
        public string UserName { get; set; }

        public string RoleId { get; set; }
    }
}