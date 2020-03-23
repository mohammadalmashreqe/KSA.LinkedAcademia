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
    public class AdminController : Controller
    {
        private readonly KSALinkedAcademiaContext _context;
        public AdminController(KSALinkedAcademiaContext kSALinkedAcademiaContext)
        {
            _context = kSALinkedAcademiaContext;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(Admin model)
        {
            if (ModelState.IsValid)
            {
                var userdetails = await _context.Admin
                .SingleOrDefaultAsync(m => m.UserName == model.UserName && m.Password == model.Password);
                if (userdetails == null)
                {
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                    return View("Index");
                }
              

            }
            else
            {
                return View("Index");
            }
            return View("HomeAdmin");
        }
    }
}