using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataBase;
using DataBase.Models;
using MVC.Infrastructure;
using Repositories;

namespace MVC.Controllers
{
    public class EnrollmentsController : BaseController
    {
        // GET: Enrollments
        public ActionResult Index()
        {
            var enrollments = this._data.Enrollments.All().Include(e => e.Course).Include(e => e.Student);
            return View(enrollments.ToList());
        }

        // GET: Enrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = this._data.Enrollments.GetById(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollments/Create
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(this._data.Courses.All(), "CourseID", "Title");
            ViewBag.StudentID = new SelectList(this._data.Students.All(), "StudentID", "LastName");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Constants.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentID,CourseID,StudentID,Grade")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                this._data.Enrollments.Add(enrollment);
                this._data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(this._data.Courses.All(), "CourseID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(this._data.Students.All(), "StudentID", "LastName", enrollment.StudentID);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = this._data.Enrollments.GetById(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(this._data.Courses.All(), "CourseID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(this._data.Students.All(), "StudentID", "LastName", enrollment.StudentID);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Constants.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentID,CourseID,StudentID,Grade")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                this._data.Enrollments.Update(enrollment);
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(this._data.Courses.All(), "CourseID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(this._data.Students.All(), "StudentID", "LastName", enrollment.StudentID);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = this._data.Enrollments.GetById(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [Authorize(Roles = Constants.AdminRole)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = this._data.Enrollments.GetById(id);
            this._data.Enrollments.Delete(enrollment);
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
