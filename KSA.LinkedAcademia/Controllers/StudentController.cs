using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSA.LinkedAcademia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSA.LinkedAcademia.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> s = new List<Student>();

        static StudentController()
        {
            s.Add(new Student { ID = 1, Email = "mm@y.com", Fname = "motaz", Lname = "Gahr", IsTeacher = false });
            s.Add(new Student { ID = 2, Email = "mm@y.com", Fname = "motaz", Lname = "Gahr", IsTeacher = false });
        }

        // GET: Student
        public ActionResult Index()
        {
            return View(s);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student r = s.Select(x => x).Where(y => y.ID == id).FirstOrDefault();
            return View(r);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student r = s.Select(x => x).Where(y => y.ID == id).FirstOrDefault();
            return View(r);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student collection)
        {
            try
            {
                // TODO: Add update logic here
                Student r = s.Select(x => x).Where(y => y.ID == id).FirstOrDefault();
                r.ID = collection.ID;
                r.Fname = collection.Fname;
                //*****************
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student r = s.Select(x => x).Where(y => y.ID == id).FirstOrDefault();
            return View(r);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student collection)
        {
            try
            {
                // TODO: Add delete logic here
                s.Remove(s.Select(x => x).Where(y => y.ID == id).FirstOrDefault());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}