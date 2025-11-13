using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebApplication1.Models;
using WebApplication1.ViewModels;

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
        private static List<string> CountryList = new List<string>
        {
            "", // empty for "Select..."
            "United States",
            "United Kingdom",
            "Canada",
            "Nigeria",
            "Ghana",
            "India"
        };
        private static List<Student> StudentsDatabase = new List<Student>()
        {
            new Student()
            {
              Id = 1,
              FirstName ="Default",
              LastName = "Student",
              Email = "defstd@gmail.com",
              Gender = "Female",
              EnrolmentDate = DateTime.Now,
              DateofBirth = DateOnly.MinValue,
              CountryofBirth = "Nigeria",
              PhoneNumber = "07452737326",
              Address = "London, United Kingdom",

              ClassTeacher = new TeachersDetailsViewModel()
              {
                  FirstName = "Mr class Teacher John",
                  LastName = "Doe",
                  Department = "EEE"
              },
              PrimaryCourse = new Course()
              {
                  CourseID = 1,
                  CourseCode = "MTS 101",
                  CourseDescription = "Intro to Maths"
              },
              OptionalCourses = new List<Course>
              {
                  new Course()
                  {
                      CourseID = 34,
                      CourseCode = "BIO 101",
                      CourseDescription = "Essential Biology"
                  },
                  new Course()
                  {
                      CourseID = 35,
                      CourseCode = "CHE 101",
                      CourseDescription = "Organic Chemistry."
                  }
              }

            },


            new Student()
            {
                Id = 2,
              FirstName ="Default",
              LastName = "Student",
              Email = "defstd@gmail.com",
              Gender = "Female",
              EnrolmentDate = DateTime.Now,
              DateofBirth = DateOnly.MinValue,
              CountryofBirth = "Nigeria",
              PhoneNumber = "07452737326",
              Address = "London, United Kingdom",

              ClassTeacher = new TeachersDetailsViewModel()
              {
                  FirstName = "Mr class ",
                  LastName = "Teacher John",
                  Department = "EEE"
              },
              PrimaryCourse = new Course()
              {
                  CourseID = 1,
                  CourseCode = "MTS 101",
                  CourseDescription = "Intro to Maths"
              },
              OptionalCourses = new List<Course>
              {
                  new Course()
                  {
                      CourseID = 34,
                      CourseCode = "BIO 101",
                      CourseDescription = "Essential Biology"
                  },
                  new Course()
                  {
                      CourseID = 35,
                      CourseCode = "CHE 101",
                      CourseDescription = "Organic Chemistry."
                  }
              }
            }
        };


        public IActionResult Index()
        {
            

            return View(StudentsDatabase);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // provide countries for the dropdown
            ViewBag.Countries = new SelectList(CountryList);
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentCreateViewModel model)
        {
            // Models folder: for Database representations.


            // 1. validate the input
            // process the creation (add the new student to the database)
            if (ModelState.IsValid == false)
            {
                // re-populate countries if we re-render the form
                ViewBag.Countries = new SelectList(CountryList, model?.CountryofBirth);
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
            var mappedStudent = new Student()
            {
                Id = id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateofBirth = model.DateofBirth,
                Gender = model.Gender,
                CountryofBirth = model.CountryofBirth,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Address = model.Address,
                EnrolmentDate = DateTime.Now,
            };
            StudentsDatabase.Add(mappedStudent);

            return RedirectToAction("Index");

            ViewBag.Message = "Student created successfully";
            
        }

        public IActionResult Details(int id)
        {

            Student studentRecord = StudentsDatabase.FirstOrDefault(student => student.Id == id);
            if (studentRecord == null)
            {
                RedirectToAction("Index");
            }
            var model = new StudentDetailViewModel()
            {
                Id = studentRecord.Id,
                FirstName = studentRecord.FirstName,
                LastName = studentRecord.LastName,
                DateofBirth = studentRecord.DateofBirth,
                CountryofBirth = studentRecord.CountryofBirth,
                PhoneNumber = studentRecord.PhoneNumber,
                Email = studentRecord.Email,
                Address = studentRecord.Address,
                EnrolmentDate = studentRecord.EnrolmentDate,
                ClassTeacher = studentRecord.ClassTeacher,
                PrimaryCourse = studentRecord.PrimaryCourse,
                OptionalCourses = studentRecord.OptionalCourses
            };

            
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var studentRecord = StudentsDatabase.FirstOrDefault(s=>s.Id == id);
            if (studentRecord == null) 
            { 
                return NotFound();
            }

            var model = new EditStudentViewModel()
            {
                Email = studentRecord.Email,
                PhoneNumber = studentRecord.PhoneNumber,
                Id = studentRecord.Id,
                Address = studentRecord.Address,
                LastName = studentRecord.LastName,
                FirstName = studentRecord.FirstName,


            };
            // supply countries and set selected to the existing value
            ViewBag.Countries = new SelectList(CountryList, model.CountryofBirth);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditStudentViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                // re-populate countries when form re-displays with errors
                ViewBag.Countries = new SelectList(CountryList, model?.CountryofBirth);
                return View(model);
            }

            var existingstudent = StudentsDatabase.FirstOrDefault(s => s.Id == model.Id);
            if (existingstudent == null)
            {
                return NotFound();
            }
            existingstudent.Id = model.Id;
            existingstudent.FirstName = model.FirstName;
            existingstudent.LastName = model.LastName;
            existingstudent.DateofBirth = model.DateofBirth;
            existingstudent.CountryofBirth = model.CountryofBirth;
            existingstudent.Gender = model.Gender;
            existingstudent.PhoneNumber = model.PhoneNumber;
            existingstudent.Address = model.Address;
            existingstudent.Email = model.Email;
            existingstudent.EnrolmentDate = DateTime.Now;

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
            var existingstudent = StudentsDatabase.FirstOrDefault(s => s.Id == model.Id);
            if (existingstudent == null) 
            {
                return NotFound();
            }
            
            StudentsDatabase.Remove(existingstudent);
            return RedirectToAction("Index");
        }
    }
}
