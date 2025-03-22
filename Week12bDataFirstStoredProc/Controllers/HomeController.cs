using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Week12bDataFirstStoredProc.AppDbContext;
using Week12bDataFirstStoredProc.Models;

namespace Week12bDataFirstStoredProc.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataContext _db;      // To use this in various views
                                               // - In C#, a constructor is a special method used
                                               // for initializing new objects of a class
        public HomeController(DataContext db)
        {
            _db = db;
        }


        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetEmployeeData()
        {
            var Emp = _db.Employees.ToList();
            return View(Emp);
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
