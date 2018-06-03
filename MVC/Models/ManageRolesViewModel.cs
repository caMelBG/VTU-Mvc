using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC.Models
{
    public class ManageRolesViewModel
    {
        public List<UserViewModel> Users{ get; set; }

        public List<SelectListItem> Roles { get; set; }
    }
}