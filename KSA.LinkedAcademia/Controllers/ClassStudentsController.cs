using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<ActionResult> Download(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot//ClassFile", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        public ActionResult Join(int id)
        {

            int uid = HttpContext.Session.GetInt32("userId").Value;

            var r = _context.ClassStudents.Select(x => x).Where(x => x.ClassId == id && x.StudentId == uid).FirstOrDefault();

            ClassStudents classStudents = new ClassStudents
            {
                ClassId = id,
                StudentId = uid
            };
            if (r == null)
            {
                _context.ClassStudents.Add(classStudents);
                _context.SaveChanges();
            }
            ViewBag.classId = id;
            var classname = _context.Class.Select(x => x).Where(x => x.Id == id).FirstOrDefault().Name;
            HttpContext.Session.SetString("ClassName", classname);
            HttpContext.Session.SetInt32("classid", id);
            var messages = from x in _context.Chat
                           where x.ClassId == id
                           select x;

            var files = from x in _context.FileStorage
                        where x.ClassId == id
                        select x;

            var cid = from x in _context.Class
                      where x.Id == id
                      select x.CreatorId;

            JoinViewModel joinViewModel = new JoinViewModel
            {
                Chats = messages.ToList(),
                FileStorages = files.ToList()
                ,
                CreatorId = cid.FirstOrDefault().HasValue ? cid.FirstOrDefault().Value : 0

                };
                return View(joinViewModel);
            
        

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

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}