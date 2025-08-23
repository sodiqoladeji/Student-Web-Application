using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class StudentsController : Controller
    {
        // CRUD -> Create, Read, Update, Delete

        // Index Action Method
        // Use this to display a list of students
        // Route:  /Students/Index
        public IActionResult Index()
        {
            return View();
        }

        // An action method for creating a new student
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
