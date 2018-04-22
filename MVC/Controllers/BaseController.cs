using DataBase;
using Repositories;
using Repositories.Interfaces;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork _data;

        public BaseController()
        {
            this._data = new UnitOfWork(new UniversityContext());
        }
    }
}