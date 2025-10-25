using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Assignment:
    /// 1. Ensure the details page load the correct student by Id.
    /// 2. Remove the unused codes and commented out codes.
    /// 3. Implement a similar dummy db for Teachers. make sure to use a proper naming for the classes.
    ///  CreateModel, DetailsMode, ListModel etc
    /// </summary>
    public class StudentsController : Controller
    {
        private static List<StudentDetailViewModel> StudentsDatabase = new List<StudentDetailViewModel>()
        {
            new StudentDetailViewModel{ Id = 1, Name ="Default Student", Email = "defstd@gmail.com"}
        };


        // CRUD -> Create, Read, Update, Delete

        // Index Action Method
        // Use this to display a list of students
        // Route:  /Students/Index
        public IActionResult Index()
        {
            /*
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
            */

            // get all existing students from the db.

            return View(StudentsDatabase);
        }

        // An action method for creating a new student
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentCreateViewModel model)
        {
            // 1. validate the input
            // process the creation (add the new student to the database)
            if (ModelState.IsValid == false)
            {
                // at this point, the modelstate is invalid
                // meaning at least one of the form fields is not passing validation rules
                // reload the form with the same data passed in
                // and show the validation errors
                return View(model);
            }

            // if we get here, then the modelstate is valid and we passed all validation rules
            // and now we can add the new student to the database

            // generate a random id for the new student
            int id = StudentsDatabase.Last().Id + 1; // new Random().Next(1, 100);
            StudentsDatabase.Add(new StudentDetailViewModel()
            {
                Id = id,
                Name = model.Name,
                Email = model.Email,
                EnrolmentDate = DateTime.Now.ToString("yyyy-MM-dd")
            });

            // LINQ

            // redirect to the student list.
            return RedirectToAction("Index");

            //ViewBag.Message = "Student created successfully";
            //return View();
        }

        public IActionResult Details()
        {
            var model = new StudentDetailViewModel();
            model.Name = "Sodiq Chan";
            model.Email = "sodiq@gmail.com";
            model.EnrolmentDate = "2024-09-01";
            return View(model);
        }
        public IActionResult CreateStudent(String Name, String Email, String EnrollmentDate)
        {
            var NewStudent = new StudentDetailViewModel();
            NewStudent.Name = Name;
            NewStudent.Email = Email;
            NewStudent.EnrolmentDate = EnrollmentDate;

            return View(NewStudent);
        }

    }
}
