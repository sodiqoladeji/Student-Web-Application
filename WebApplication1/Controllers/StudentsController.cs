using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
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

        public IActionResult Index()
        {
            

            return View(StudentsDatabase);
        }

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
                EnrolmentDate = model.EnrolmentDate
            });

            return RedirectToAction("Index");

            //ViewBag.Message = "Student created successfully";
            
        }

        public IActionResult Details(int id)
        {

            StudentDetailViewModel model = StudentsDatabase.FirstOrDefault(student => student.Id == id);
            if (model == null) 
            {
                 RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = StudentsDatabase.FirstOrDefault(s=>s.Id == id);
            if (model == null) 
            { 
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentDetailViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            var student = StudentsDatabase.FirstOrDefault(s => s.Id == model.Id);
            if (student == null)
            {
                return NotFound();
            }
            student.Name = model.Name;
            student.Email = model.Email;
            student.EnrolmentDate = model.EnrolmentDate;


            return RedirectToAction("Details", new { id = model.Id });
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = StudentsDatabase.FirstOrDefault(s => s.Id == id);
            if (ModelState.IsValid == false) 
            {
                return NotFound();
            }
            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(StudentDetailViewModel model)
        {
            var student = StudentsDatabase.FirstOrDefault(s => s.Id == model.Id);
            if (student == null) 
            {
                return NotFound();
            }
            
            StudentsDatabase.Remove(student);
            return RedirectToAction("Index");
        }
    }
}
