using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            //_db.Employees.Add(obj);      // adding to SQL query    //constructor part

            _db.Database.ExecuteSqlRaw(
                "exec InsertEmployee @FirstName, @LastName, @Address",
                new SqlParameter("@FirstName", obj.FirstName),
                new SqlParameter("@LastName", obj.LastName),
                new SqlParameter("@address", obj.Address)
                );
            _db.SaveChanges();      // Saving
            return View();
        }


        [HttpGet]
        public IActionResult GetEmployeeData()
        {
            //var Emp = _db.Employees.ToList();
            var Emp = _db.Employees.FromSqlRaw("exec SelectEmployeeData");
            return View(Emp);
        }


        public IActionResult Delete(int id)
        {
            // var Emp = _db.Employee.FirstOrDefault(x => x.id == id);
            //_db.Employee.Remove(Emp);


            _db.Database.ExecuteSqlRaw("execute DeleteEmployee @id={0}", id);
            _db.SaveChanges();
            return RedirectToAction("GetEmployeeData");
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
