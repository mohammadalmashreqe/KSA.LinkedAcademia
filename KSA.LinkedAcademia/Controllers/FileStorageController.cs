using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KSA.LinkedAcademia.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KSA.LinkedAcademia.Controllers
{
    public class FileStorageController : Controller
    {
        private readonly KSALinkedAcademiaContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;




        public FileStorageController(KSALinkedAcademiaContext kSALinkedAcademiaContext, IHostingEnvironment hostingEnvironment)
        {
            _context = kSALinkedAcademiaContext;
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult Index(int id)
        {
            var files = _context.FileStorage.Include(x => x.Class).Select(x => x).Where(x => x.StudentId == id);
            //var files = from x in _context.FileStorage
            //            where x.StudentId == id
            //            select x; 
            return View(files);
        }
        // GET: FileStorage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FileStorage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FileStorage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(List<IFormFile> files)
        {
            try
            {
                // TODO: Add insert logic here
                long size = files.Sum(f => f.Length);

                var filePaths = new List<string>();
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        // full path to file in temp location
                        var path = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot//ClassFile",
                      formFile.FileName);
                        //var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "ClassFile");
                        //filePaths.Add(filePath);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        _context.Add(new FileStorage
                        {
                            Name = formFile.FileName,
                            Path = path,
                            ClassId = HttpContext.Session.GetInt32("classid"),
                            StudentId = HttpContext.Session.GetInt32("userId")
                        });
                        _context.SaveChanges();
                    }

                }

                // process uploaded files
                // Don't rely on or trust the FileName property without validation.
                ViewBag.Message = "file uploaded";
                // return RedirectToAction(nameof(Index), new { id = HttpContext.Session.GetInt32("userId") });
                return View("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: FileStorage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FileStorage/Edit/5

        // GET: FileStorage/Delete/5
        public ActionResult Delete(int id)
        {
            var file = _context.FileStorage.Include(x => x.Class).Select(x => x).Where(x => x.Id == id).SingleOrDefault();
            return View(file);
        }

        // POST: FileStorage/Delete/5
        [HttpPost]
        public ActionResult Delete(FileStorage item, int id)
        {
            var file = _context.FileStorage.Select(x => x).Where(x => x.Id == id).SingleOrDefault();
            _context.FileStorage.Remove(file);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), new { id = HttpContext.Session.GetInt32("userId") });

        }
    }
}