using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KSA.LinkedAcademia.Models;

namespace KSA.LinkedAcademia.Controllers
{
    public class HomeController : Controller
    {
        public static List<University> u = new List<University>();

        static HomeController()
        {
            u.Add(new University { Id = 1, Name = "King Khalid Universty"});
            u.Add(new University { Id = 2, Name = "Princess Noora Universty"});
            u.Add(new University { Id = 3, Name = "King Abdulaziz University" });
        }
        public IActionResult Index()
        {
            return View(u);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
