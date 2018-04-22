using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataBase.Models;
using MVC.Infrastructure;
using MVC.Models;
using PagedList;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class StudentsController : BaseController
    {
        // GET: Students
        public ActionResult Index(int page = 1, string query = "", OrderType order = OrderType.Default)
        {
            ViewData["query"] = query;
            ViewData["order"] = (int)order;
            var model = this._data.Students.All()
                .Where(x => x.FirstMidName.Contains(query))
                .Where(x => x.LastName.Contains(query));
            if (order == OrderType.ByFirstName)
            {
                model = model.OrderBy(x => x.FirstMidName);
            }
            else if (order == OrderType.ByLastName)
            {
                model = model.OrderBy(x => x.LastName);
            }
            else
            {
                model = model.OrderBy(x => x.EnrollmentDate);
            }

            return View(model.ProjectTo<StudentViewModel>().ToPagedList(page, 5));
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = Mapper.Map<StudentViewModel>(this._data.Students.GetById(id));
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Students/Create
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Constants.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,LastName,FirstMidName,EnrollmentDate")] StudentViewModel model)
        {
            var student = Mapper.Map<Student>(model);
            if (ModelState.IsValid)
            {
                this._data.Students.Add(student);
                this._data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Students/Edit/5
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = Mapper.Map<StudentViewModel>(this._data.Students.GetById(id));
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Constants.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,LastName,FirstMidName,EnrollmentDate")] StudentViewModel model)
        {
            var student = Mapper.Map<Student>(model);
            if (ModelState.IsValid)
            {
                this._data.Students.Update(student);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Students/Delete/5
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var student = Mapper.Map<StudentViewModel>(this._data.Students.GetById(id));
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [Authorize(Roles = Constants.AdminRole)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = Mapper.Map<StudentViewModel>(this._data.Students.GetById(id));
            this._data.Students.Delete(model);
            this._data.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._data.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
