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
    public class AccountController : Controller
    {
        private readonly KSALinkedAcademiaContext _context;

        public AccountController(KSALinkedAcademiaContext kSALinkedAcademiaContext)
        {
            _context = kSALinkedAcademiaContext;
        }
        public IActionResult Index()
        {
            return View("Login");
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userdetails = await _context.Student
                .SingleOrDefaultAsync(m => m.Email == model.Email && m.Password == model.Password);
                if (userdetails == null)
                {
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                    return View("Login");
                }
                HttpContext.Session.SetString("StudentName", userdetails.Fname);
                HttpContext.Session.SetInt32("userId",userdetails.Id);
                HttpContext.Session.SetString("universityId", userdetails.UniversityId+"");


            }
            else
            {
                return View("Login");
            }
            return RedirectToAction("Home", "Student");
        }


        [HttpPost]
        public async Task<ActionResult> Registar(RegistrationViewModel model)
        {

            if (ModelState.IsValid)
            {
                Student user = new Student
                {
                    Fname = model.FName,
                    Lname = model.LName,
                    Email = model.Email,
                    Password = model.Password,
                    Mobile = model.Mobile,
                    UniversityId = model.UniversityID

                };
                _context.Add(user);
                await _context.SaveChangesAsync();

            }
            else
            {
                ViewBag.university = _context.University;

                return View("Registration");
            }
            return RedirectToAction("Index", "Account");
        }
        // registration Page load
        public IActionResult Registration()
        {
            ViewData["Message"] = "Registration Page";
            ViewBag.university = _context.University;

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}