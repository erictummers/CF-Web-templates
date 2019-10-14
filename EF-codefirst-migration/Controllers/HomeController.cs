using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF_codefirst_migration.Models;
using EF_codefirst_migration.Context;
using Microsoft.Extensions.Logging;

namespace EF_codefirst_migration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy([FromServices] SchoolContext context)
        {
            try {
                ViewData["Message"] = $"{context.Students.Count()} students found.";
            } catch (Exception ex) {
                _logger.LogError(ex, "Student count failed, fallback");
                ViewData["Message"] = "no data.";
            }      
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
