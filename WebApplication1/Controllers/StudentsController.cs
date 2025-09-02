using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

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
            var students = new List<StudentDetailViewModel>();
            students.Add(new StudentDetailViewModel()
            {
                Name = "Sodiq Yusuff",
                Email = "syusuff@gmail.com",
                EnrolmentDate = "Today"
            });

            students.Add(new StudentDetailViewModel()
            {
                Name = "Sodiq Oladeji",
                Email = "soladeji@gmail.com",
                EnrolmentDate = "2025-10-11"
            });

            students.Add(new StudentDetailViewModel()
            {
                Name = "James Yusuff",
                Email = "jy@gmail.com",
                EnrolmentDate = "2025-10-11"
            });
            students.Add(new StudentDetailViewModel()
            {
                Name = "poco lee",
                Email = "plee@gmail.com",
                EnrolmentDate = "2025-10-11"
            });

            students.Add(new StudentDetailViewModel()
            {
                Name = "Ademola Lukman",
                Email = "amola@gmail.com",
                EnrolmentDate = "2028-10-11"
            });

            return View(students);
        }

        // An action method for creating a new student
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details()
        {
            var model = new StudentDetailViewModel();
            model.Name = "Sodiq Chan";
            model.Email = "sodiq@gmail.com";
            model.EnrolmentDate = "2024-09-01";
            return View(model);
        }
    }
}
