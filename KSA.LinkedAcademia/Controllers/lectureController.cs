using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KSA.LinkedAcademia.Models;


namespace KSA.LinkedAcademia.Controllers
{
    public class LectureController : Controller
    {
        public static List<Lecture> L = new List<Lecture>();
        public static List<Student> s = new List<Student>();
        public static Student CR = new Student();
        static LectureController()
        {
            L.Add(new Lecture { Id = 1,Creator= CR,Students=s});
      
        }
            

        // GET: Class
        public ActionResult Index()
        {
            return View();
        }

        // GET: Class/Details/5
        public ActionResult Details(int id)
        {
            Lecture le = L.Select(x => x).Where(y => y.Id == id).FirstOrDefault();
            
            return View(le);
        }

        // GET: Class/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Class/Create
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

        // GET: Class/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Class/Edit/5
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

        // GET: Class/Delete/5
        public ActionResult Delete(int id)
        {
            Lecture le = L.Select(x => x).Where(y => y.Id == id).FirstOrDefault();
            return View(le);
            
        }

        // POST: Class/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                L.Remove(L.Select(x => x).Where(y => y.Id == id).FirstOrDefault());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}