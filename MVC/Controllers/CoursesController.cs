using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataBase.Models;
using MVC.Infrastructure;
using MVC.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CoursesController : BaseController
    {
        // GET: Courses
        public ActionResult Index()
        {
            return View(this._data.Courses.All().ProjectTo<CourseViewModel>().ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var course = Mapper.Map<CourseViewModel>(this._data.Courses.GetById(id));
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Constants.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Title,Credits")] CourseViewModel model)
        {
            var course = Mapper.Map<Course>(model);
            if (ModelState.IsValid)
            {
                this._data.Courses.Add(course);
                this._data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Courses/Edit/5
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = Mapper.Map<CourseViewModel>(this._data.Courses.GetById(id));
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Constants.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Title,Credits")] CourseViewModel model)
        {
            var course = Mapper.Map<Course>(model);
            if (ModelState.IsValid)
            {
                this._data.Courses.Update(course);
                this._data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Courses/Delete/5
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = Mapper.Map<CourseViewModel>(this._data.Courses.GetById(id));
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Courses/Delete/5
        [Authorize(Roles = Constants.AdminRole)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = Mapper.Map<CourseViewModel>(this._data.Courses.GetById(id));
            this._data.Courses.Delete(model);
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
