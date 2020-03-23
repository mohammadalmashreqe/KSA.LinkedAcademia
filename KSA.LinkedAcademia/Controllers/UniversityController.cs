using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSA.LinkedAcademia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KSA.LinkedAcademia.Controllers
{
    public class UniversityController : Controller
    {
        private readonly KSALinkedAcademiaContext _context;

        public UniversityController(KSALinkedAcademiaContext kSALinkedAcademiaContext)
        {
            _context = kSALinkedAcademiaContext;
        }
        // GET: University
        public ActionResult Index()
        {
            return View(_context.University);
        }

        // GET: University/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var un = await _context.University.SingleOrDefaultAsync(m => m.Id == id);

            return View(un);
        }

        // GET: University/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: University/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(University collection)
        {
            try
            {
                // TODO: Add insert logic here
                University u = new University
                {
                    Name = collection.Name,

                };
                _context.Add(u);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: University/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var un = await _context.University.SingleOrDefaultAsync(m => m.Id == id);
            return View(un);
        }

        // POST: University/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, University collection)
        {
            try
            {
                // TODO: Add update logic here
                var un = await _context.University.SingleOrDefaultAsync(m => m.Id == id);
                un.Name = collection.Name;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: University/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var un = await _context.University.SingleOrDefaultAsync(m => m.Id == id);

            return View(un);
        }

        // POST: University/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var un = await _context.University.SingleOrDefaultAsync(m => m.Id == id);
                _context.University.Remove(un);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}