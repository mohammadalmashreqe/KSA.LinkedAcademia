using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSA.LinkedAcademia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSA.LinkedAcademia.Controllers
{
    public class ClassController : Controller
    {
        private readonly KSALinkedAcademiaContext _context;
        public ClassController(KSALinkedAcademiaContext kSALinkedAcademiaContext)
        {
            _context = kSALinkedAcademiaContext;
        }

        // GET: Class
        public ActionResult Index()
        {
            return View();
        }

        // GET: Class/Details/5
        public ActionResult Details(int id)
        {
            var cls = _context.Class.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
            return View(cls);
        }

        // GET: Class/Create
        public ActionResult Create()
        {
           int UNID=int.Parse( HttpContext.Session.GetString("universityId"));
            var un = _context.University.Select(x => x).Where(x => x.Id == UNID).FirstOrDefault();
            ViewBag.UnivirsetyName =un.Name;
            Class cls = new Class
            {
                CreatorId = HttpContext.Session.GetInt32("userId"),
                UnivirsetyId = UNID
            };
            return View(cls);
        }

        // POST: Class/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Class model,int CreatorId,int UnivirsetyId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Class cls = new Class
                    {
                        Name = model.Name,
                        CreatorId = CreatorId,
                        UnivirsetyId = UnivirsetyId

                    };
                   cls= _context.Add(cls).Entity;
                    _context.SaveChanges();

               
                    return RedirectToAction("details", new { id =cls.Id });
                }
                else
                    return View("Error");

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
            return View();
        }

        // POST: Class/Delete/5
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