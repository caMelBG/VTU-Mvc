using Repositories.Interfaces;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork _data;

        public BaseController(IUnitOfWork data)
        {
            this._data = data;
        }
    }
}