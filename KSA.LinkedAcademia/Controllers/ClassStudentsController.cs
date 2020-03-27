using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSA.LinkedAcademia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSA.LinkedAcademia.Controllers
{
    public class ClassStudentsController : Controller
    {
        private readonly KSALinkedAcademiaContext _context;

        public ClassStudentsController(KSALinkedAcademiaContext kSALinkedAcademiaContext)
        {
            _context = kSALinkedAcademiaContext;
        }
        // GET: ClassStudents
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Join(int id)
        {

            int uid = HttpContext.Session.GetInt32("userId").Value;

            var r= _context.ClassStudents.Select(x => x).Where(x => x.ClassId == id && x.StudentId == uid).FirstOrDefault();
            if (r == null)
            {
                ClassStudents classStudents = new ClassStudents
                {
                    ClassId = id,
                    StudentId = uid
                };
                _context.ClassStudents.Add(classStudents);
                _context.SaveChanges();
                ViewBag.classId = id;
                return View();
            }
            else
            {
                
                return View("Error");
            }
        }

        // GET: ClassStudents/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClassStudents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassStudents/Create
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

        // GET: ClassStudents/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClassStudents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClassStudents/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClassStudents/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}